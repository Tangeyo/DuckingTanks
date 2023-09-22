using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPowerUp : MonoBehaviour
{
    public float speedMultiplier = 2f; // The factor by which the speed will be boosted
    public float powerUpDuration = 10f; // Duration of the power-up in seconds
    public Color powerUpColor = Color.magenta; // Color of the tank during the power-up

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tank"))
        {
            TankScript tankScript = other.GetComponent<TankScript>();

            // Apply the speed boost power-up to the tank
            tankScript.ApplySpeedBoost(speedMultiplier, powerUpDuration, powerUpColor);

            // Destroy the power-up object
            Destroy(gameObject);
        }
    }
}
