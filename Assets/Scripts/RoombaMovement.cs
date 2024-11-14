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
        if (isMovingForward)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            distanceTraveled += moveSpeed * Time.deltaTime;

            if (distanceTraveled >= moveDistance)
            {
                isMovingForward = false;
                distanceTraveled = 0f;
                rotationTimer = 0f; // Reset rotation timer
            }
        }
        else
        {
            rotationTimer += Time.deltaTime;
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            
            if (rotationTimer >= rotationDuration)
            {
                isMovingForward = true;
                rotationTimer = 0f; // Reset rotation timer
            }
        }
    }
}
