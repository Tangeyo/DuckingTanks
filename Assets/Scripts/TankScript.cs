using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float moveSpeed = 5f; // Default move speed for Tank (WASD controls)
    public float moveSpeedTank2 = 5f; // Move speed for Tank2 (IJKL controls)
    public float rotationSpeed = 100f;
    private string tankName;

    public GameObject bulletPrefab; // The bullet prefab to shoot
    public float bulletSpeed = 10f; // Speed of the bullets
    public float bulletDelay = 0.5f; // Delay between bullet shots
    // Start is called before the first frame update

     // Respawn variables
    public Transform respawnPoint;
    public float respawnDelay = 2f;
    private bool isRespawning = false;

    void Start()
    {
        // Rotate the tank to face to the right at the start
        transform.rotation = Quaternion.Euler(0f, 0f, -90f);

        // Get the name of the tank GameObject
        tankName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {

        if (isRespawning)
            return;

        float horizontalInput = 0f;
        float verticalInput = 0f;
        float currentMoveSpeed = moveSpeed; // Default move speed for Tank


        // Check the name of the tank GameObject
        if (tankName == "Tank")
        {
            // Player 1 controls using default Horizontal and Vertical input axes (WASD)
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.E))
        {
            // Call the ShootBullet function to shoot a bullet for Player 1
            ShootBullet();
        }

        }
        else if (tankName == "Tank2")
        {
            // Player 2 controls using custom keys (IJKL)
            if (Input.GetKey(KeyCode.I))
            {
                verticalInput = moveSpeedTank2;
            }
            else if (Input.GetKey(KeyCode.K))
            {
                verticalInput = -moveSpeedTank2;
            }

            if (Input.GetKey(KeyCode.J))
            {
                horizontalInput = -moveSpeedTank2;
            }
            else if (Input.GetKey(KeyCode.L))
            {
                horizontalInput = moveSpeedTank2;
            }

            currentMoveSpeed = moveSpeedTank2; // Set the move speed for Tank2

            if (Input.GetKeyDown(KeyCode.U)) // Player 2 shoots with the "U" key
        {
            Debug.Log("Player 2 shooting!");
            // Call the ShootBullet function to shoot a bullet for Player 2
            ShootBullet();
        }

        }

        // Move forward or backward
        myRigidbody.velocity = transform.up * verticalInput * currentMoveSpeed;

        // Rotate left or right
        myRigidbody.angularVelocity = -horizontalInput * rotationSpeed;
    

    }

    void ShootBullet()
{
    // Get the position of the barrel (assuming it's a child of the tank)
    Vector3 barrelPosition = transform.Find("Barrel").position;

    // Instantiate a new bullet at the barrel's position and rotation
    GameObject bullet = Instantiate(bulletPrefab, barrelPosition, transform.rotation);

    // Get the bullet's Rigidbody2D component
    Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

    // Apply a force to the bullet in the forward direction (up for the tank)
    bulletRigidbody.velocity = transform.up * bulletSpeed;

    // Ignore collisions between the bullet and the tank that shot it
    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
}


public void ApplySpeedBoost(float multiplier, float duration, Color color)
{
    // Apply speed boost effect
    moveSpeed *= multiplier;

    // Change tank's color to indicate the power-up
    Renderer tankRenderer = GetComponent<Renderer>();
    tankRenderer.material.color = color;

    // Start a coroutine to revert the tank's speed and color after the duration
    StartCoroutine(RevertSpeedBoost(multiplier, duration, Color.white));
}

private IEnumerator RevertSpeedBoost(float multiplier, float duration, Color originalColor)
{
    yield return new WaitForSeconds(duration);

    // Revert speed and color to original values
    moveSpeed /= multiplier;
    Renderer tankRenderer = GetComponent<Renderer>();
    tankRenderer.material.color = originalColor;
}


    // ... (other variables and methods)
 public void ApplyHealingPowerUp(int healingAmount, float effectDuration, Color powerUpColor)
    {
        StartCoroutine(HealingPowerUpRoutine(healingAmount, effectDuration, powerUpColor));
    }

    private IEnumerator HealingPowerUpRoutine(int healingAmount, float effectDuration, Color powerUpColor)
    {
        // Apply the visual effect
        Renderer tankRenderer = GetComponent<Renderer>();
        Color originalColor = tankRenderer.material.color;
        tankRenderer.material.color = powerUpColor;

        // Heal the tank
        TankHealth tankHealth = GetComponent<TankHealth>();
        tankHealth.Heal(healingAmount);

        yield return new WaitForSeconds(effectDuration);

        // Reset the tank's color
        tankRenderer.material.color = originalColor;
    }


     public void Die()
    {
        isRespawning = true;
        StartCoroutine(RespawnAfterDelay());
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);

        // Move the tank to the respawn point
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        // Reset tank's color
        Renderer tankRenderer = GetComponent<Renderer>();
        tankRenderer.material.color = Color.white;

        // Reset other properties as needed

        isRespawning = false;
    }





}
