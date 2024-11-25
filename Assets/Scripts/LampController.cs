using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampController : MonoBehaviour
{
    public Toggle lampUI; // Assign LampUI in the Inspector
    public GameObject lamp; // Assign Lamp object in the Inspector
    public bool defaultState;

    private Light light;

    void Start()
    {

        if (lamp != null)
        {
            // Get the Lamp's movement script
            light = lamp.GetComponentInChildren<Light>();
        }

        if (lampUI != null)
        {
            // Initialize the Toggle's state based on the movement script's activity
            if (light != null)
            {
                lampUI.isOn = light.enabled;
            }

            // Add listener for when the Toggle's value changes
            lampUI.onValueChanged.AddListener(OnToggleValueChanged);
            lampUI.gameObject.SetActive(defaultState);
        }
    }

    void OnToggleValueChanged(bool isOn)
    {
        if (light != null)
        {
            // Enable or disable the Lamp's movement script based on the Toggle's state
            light.enabled = isOn;
        }
    }

    void Update()
    {
        // Update the Toggle's state if the movement script's enabled state changes elsewhere
        if (light != null && lampUI != null)
        {
            if (lampUI.isOn != light.enabled)
            {
                lampUI.isOn = light.enabled;
            }
        }
    }

    void OnDestroy()
    {
        // Remove listener to prevent memory leaks
        if (lampUI != null)
        {
            lampUI.onValueChanged.RemoveListener(OnToggleValueChanged);
        }
    }
}