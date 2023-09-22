using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowCamera : MonoBehaviour
{
    public Transform target;          // The player's Transform (the object the camera will follow)
    public float smoothSpeed = 0.125f; // The smoothness factor (smaller values make the camera follow smoother)

    private Vector3 offset;           // The initial offset between the camera and the player

    private void Start()
    {
        // Calculate the initial offset between the camera and the player
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
        // Calculate the desired position for the camera
        Vector3 desiredPosition = target.position + offset;

        // Interpolate the camera's position smoothly towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Update the camera's position
        transform.position = smoothedPosition;

        }
        
    }
}
