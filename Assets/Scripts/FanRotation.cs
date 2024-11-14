using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour
{
    //Give the option for the user to define which axis has speed
    public float xSpeed;
    public float ySpeed;
    public float zSpeed;
    void Update()
    {
        // Rotate the object around the any axis that is given a speed value
        transform.Rotate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
    }
}
