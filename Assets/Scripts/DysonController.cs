using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DysonController : MonoBehaviour
{
    public Toggle dysonUI; // Assign DysonUI in the Inspector
    public GameObject dyson; // Assign Dyson object in the Inspector
    public bool defaultState;

    private FanRotation dysonMovementScript;

    void Start()
    {

        if (dyson != null)
        {
            // Get the Dyson's movement script
            dysonMovementScript = dyson.GetComponent<FanRotation>();
        }

        if (dysonUI != null)
        {
            // Initialize the Toggle's state based on the movement script's activity
            if (dysonMovementScript != null)
            {
                dysonUI.isOn = dysonMovementScript.enabled;
            }

            // Add listener for when the Toggle's value changes
            dysonUI.onValueChanged.AddListener(OnToggleValueChanged);
            dysonUI.gameObject.SetActive(defaultState);
        }
    }

    void OnToggleValueChanged(bool isOn)
    {
        if (dysonMovementScript != null)
        {
            // Enable or disable the Dyson's movement script based on the Toggle's state
            dysonMovementScript.enabled = isOn;
        }
    }

    void Update()
    {
        // Update the Toggle's state if the movement script's enabled state changes elsewhere
        if (dysonMovementScript != null && dysonUI != null)
        {
            if (dysonUI.isOn != dysonMovementScript.enabled)
            {
                dysonUI.isOn = dysonMovementScript.enabled;
            }
        }
    }

    void OnDestroy()
    {
        // Remove listener to prevent memory leaks
        if (dysonUI != null)
        {
            dysonUI.onValueChanged.RemoveListener(OnToggleValueChanged);
        }
    }
}