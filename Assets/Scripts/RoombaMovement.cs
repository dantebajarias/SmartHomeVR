using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotationSpeed = 180f;
    public float moveDistance = 5f;
    public float rotationDuration = 3f;

    private bool isMovingForward = true;
    private float distanceTraveled = 0f;
    private float rotationTimer = 0f;

    void Update()
    {
        if (isMovingForward) //Check if roomba is moving forward
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //Move the roomba forward
            distanceTraveled += moveSpeed * Time.deltaTime; //Keep track of the distance traveled

            if (distanceTraveled >= moveDistance) //Once target distance reached, stop roomba
            {
                isMovingForward = false;
                distanceTraveled = 0f;
                rotationTimer = 0f; // Reset rotation timer
            }
        }
        else //If roomba stops moving
        {
            rotationTimer += Time.deltaTime; //Increase rotation timer
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); //Rotate the roomba

            if (rotationTimer >= rotationDuration) //Once target duration reached, start roomba movement
            {
                isMovingForward = true;
                rotationTimer = 0f; // Reset rotation timer
            }
        }
    }
}
