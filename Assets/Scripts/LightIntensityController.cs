using UnityEngine;
using UnityEngine.UI;

public class LightIntensityController : MonoBehaviour
{
    // Reference to the Light component
    public Light targetLight;

    // Reference to the Slider UI component
    public Slider intensitySlider;

    // Default intensity value
    public float defaultIntensity;

    void OnEnable()
    {
        // Check if the targetLight is assigned
        if (targetLight == null)
        {
            Debug.LogError("Please assign a Light component to the LightIntensityController script.");
            return;
        }

        // Initialize the light's intensity
       

        // Initialize the slider's value
        if (intensitySlider != null)
        {
            defaultIntensity = intensitySlider.value;
        }
        else
        {
            Debug.LogError("Please assign a Slider component to the LightIntensityController script.");
        }
        targetLight.intensity = defaultIntensity;
    }
    // Method called when the slider's value changes
    void Update()
    {
        if (targetLight != null)
        {
            targetLight.intensity = intensitySlider.value;
        }
    }
}
