using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPowerUp : MonoBehaviour
{
    public int healingAmount = 20; // Amount of health to heal
    public float effectDuration = 5f; // Duration of the visual effect
    public Color powerUpColor = Color.green; // Color of the tank during the power-up

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tank"))
        {
            TankScript tankScript = other.GetComponent<TankScript>();

            // Apply healing power-up and color change
            tankScript.ApplyHealingPowerUp(healingAmount, effectDuration, powerUpColor);

            // Destroy the power-up object
            Destroy(gameObject);
        }
    }
}

