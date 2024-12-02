using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RoombaSpeedButtonController : MonoBehaviour
{
    [Header("References")]
    public RoombaMovement roombaMovementScript; // Reference to the RoombaController script

    [Header("Button Settings")]
    public Button increaseSpeedButton; // Button to increase speed
    public Button decreaseSpeedButton; // Button to decrease speed

    [Header("Speed Adjustment")]
    public float speedStep = 0.25f; // Amount to increase/decrease speed per button press

    public TextMeshProUGUI speedDisplayText;

    void Start()
    {
        if (roombaMovementScript == null)
        {
            Debug.LogError("Please assign the RoombaController script.");
            return;
        }

        if (increaseSpeedButton == null || decreaseSpeedButton == null)
        {
            Debug.LogError("Please assign both Increase and Decrease Speed Buttons.");
            return;
        }

        speedDisplayText.text = roombaMovementScript.moveSpeed.ToString("F2");

        // Add listeners to handle button clicks
        increaseSpeedButton.onClick.AddListener(OnIncreaseSpeedButtonClicked);
        decreaseSpeedButton.onClick.AddListener(OnDecreaseSpeedButtonClicked);
    }

    void OnIncreaseSpeedButtonClicked()
    {
        roombaMovementScript.moveSpeed = Math.Min(roombaMovementScript.moveSpeed + speedStep, 5);
        speedDisplayText.text = roombaMovementScript.moveSpeed.ToString("F2");
    }

    void OnDecreaseSpeedButtonClicked()
    {
        roombaMovementScript.moveSpeed = Math.Max(roombaMovementScript.moveSpeed - speedStep, 0);
        speedDisplayText.text = roombaMovementScript.moveSpeed.ToString("F2");
    }

    void OnDestroy()
    {
        // Remove listeners to prevent memory leaks
        if (increaseSpeedButton != null)
        {
            increaseSpeedButton.onClick.RemoveListener(OnIncreaseSpeedButtonClicked);
        }
        if (decreaseSpeedButton != null)
        {
            decreaseSpeedButton.onClick.RemoveListener(OnDecreaseSpeedButtonClicked);
        }
    }
}
