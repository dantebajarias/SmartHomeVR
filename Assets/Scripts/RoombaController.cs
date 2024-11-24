using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoombaController : MonoBehaviour
{
    public Toggle roombaUI; // Assign RoombaUI in the Inspector
    public GameObject roomba; // Assign Roomba object in the Inspector

    private RoombaMovement roombaMovementScript;

    void Start()
    {

        if (roomba != null)
        {
            // Get the Roomba's movement script
            roombaMovementScript = roomba.GetComponent<RoombaMovement>();
        }

        if (roombaUI != null)
        {
            // Initialize the Toggle's state based on the movement script's activity
            if (roombaMovementScript != null)
            {
                roombaUI.isOn = roombaMovementScript.enabled;
            }

            // Add listener for when the Toggle's value changes
            roombaUI.onValueChanged.AddListener(OnToggleValueChanged);
            roombaUI.gameObject.SetActive(false);
        }
    }

    void OnToggleValueChanged(bool isOn)
    {
        if (roombaMovementScript != null)
        {
            // Enable or disable the Roomba's movement script based on the Toggle's state
            roombaMovementScript.enabled = isOn;
        }
    }

    void Update()
    {
        // Update the Toggle's state if the movement script's enabled state changes elsewhere
        if (roombaMovementScript != null && roombaUI != null)
        {
            if (roombaUI.isOn != roombaMovementScript.enabled)
            {
                roombaUI.isOn = roombaMovementScript.enabled;
            }
        }
    }

    void OnDestroy()
    {
        // Remove listener to prevent memory leaks
        if (roombaUI != null)
        {
            roombaUI.onValueChanged.RemoveListener(OnToggleValueChanged);
        }
    }
}
