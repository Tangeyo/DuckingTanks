using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    public int maxHealth = 100;
     public int maxLives = 3; // Number of lives
    private int currentHealth;
     private int currentLives; // Current number of lives
    
    public HealthBar healthBar; // Reference to the HealthBar script
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentLives = maxLives;
        
        // Set the maximum health for the health bar
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damageAmount) 
    {
        currentHealth -= damageAmount;
        
        // Update the health bar display
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentLives--;

            if (currentLives <= 0)
            {
                Destroy(gameObject); // Tank is out of lives, destroy it
            }
            else
            {
                Respawn(); // Tank has more lives, respawn it
            }
        }
    }

    public void Heal(int healAmount)
{
    currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
    healthBar.SetHealth(currentHealth);
}

private void Respawn()
    {
        currentHealth = maxHealth;
        // Implement respawn logic, such as resetting position and other properties
    }


    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
