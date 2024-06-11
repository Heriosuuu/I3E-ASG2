using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 20f;

    private void OnTriggerEnter(Collider other)
    {
        // Check if collided with player or enemy
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            // Deal damage to the player or enemy if collided with them
            if (other.CompareTag("Player"))
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                }
            }


            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}

