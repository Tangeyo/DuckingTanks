using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damageAmount = 20;

    public float speed = 10f; // Speed of the bullet

    void Start()
    {
        // Set the initial velocity to move the bullet forward (up for 2D)
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tank"))
        {
            TankHealth tankHealth = collision.gameObject.GetComponent<TankHealth>();
            if (tankHealth != null)
            {
                tankHealth.TakeDamage(damageAmount);
                Destroy(gameObject);
            }
        }
        
        if (collision.gameObject.CompareTag("UnbreakableWall"))
        {
            Destroy(gameObject); // Destroy bullet on collision with UnbreakableWall
        }
    }


}

