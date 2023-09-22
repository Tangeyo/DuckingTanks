using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public int maxHits = 3; // Number of hits required to destroy the wall
    private int currentHits = 0; // Current number of hits

    public GameObject destroyEffect; // Particle effect for destruction

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            currentHits++;

            if (currentHits >= maxHits)
            {
                DestroyWall();
            }
        }
    }

    void DestroyWall()
    {
        if (destroyEffect != null)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
