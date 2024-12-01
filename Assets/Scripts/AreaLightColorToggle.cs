using UnityEngine;
using UnityEngine.UI;

public class AreaLightColorToggle : MonoBehaviour
{
    // Reference to the Area Light in your scene
    public Light areaLight;

    // Reference to the Toggle UI component
    public Toggle colorToggle;

    // Colors to switch between
    public Color colorOn;

    void Start()
    {
        // Ensure the Toggle and Area Light are assigned
        if (colorToggle == null || areaLight == null)
        {
            Debug.LogError("Please assign the Toggle and Area Light in the inspector.");
            return;
        }

        if (colorToggle.isOn)
        {
            areaLight.color = colorOn; // Set light color to 'colorOn'
        }

        // Add a listener to detect when the Toggle is pressed
        colorToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    // Method called when the Toggle value changes
    void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            areaLight.color = colorOn; // Set light color to 'colorOn'
        }
    }
}
