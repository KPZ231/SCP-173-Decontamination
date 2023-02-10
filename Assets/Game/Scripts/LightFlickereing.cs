using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickereing : MonoBehaviour
{
    private Light lightToFlicker;
    public float minIntensity = 5f; // the minimum intensity of the light
    public float maxIntensity = 1.5f; // the maximum intensity of the light
    public float flickerSpeed = 0.1f; // the speed of the flicker in seconds

    void Start()
    {
        lightToFlicker = this.GetComponent<Light>();
        // Call the FlickerLight function repeatedly
        InvokeRepeating("FlickerLight", 0f, flickerSpeed);
    }

    void FlickerLight()
    {
        // Set the intensity of the light to a random value between minIntensity and maxIntensity
        lightToFlicker.intensity = Random.Range(minIntensity, maxIntensity);
    }

}
