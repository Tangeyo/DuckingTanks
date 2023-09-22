using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    // Reference to the UI camera
    public Camera uiCamera;

    void Update()
    {
        // Get the bullet's position in screen coordinates
        Vector3 screenPos = uiCamera.WorldToScreenPoint(transform.position);

        // Check if the bullet is outside the UI camera's view
        if (screenPos.x < 0 || screenPos.x > Screen.width || screenPos.y < 0 || screenPos.y > Screen.height)
        {
            // Destroy the bullet if it's outside the UI camera's view
            Destroy(gameObject);
        }
    }
}
