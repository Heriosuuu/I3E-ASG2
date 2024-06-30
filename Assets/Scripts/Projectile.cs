/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Handles the behavior of projectiles in the game. Deals damage to the player or enemy upon collision and destroys the projectile.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 20f; // Damage amount inflicted on collision

    /// <summary>
    /// Checks for collision with other objects. Deals damage to the player or enemy if collided with them and destroys the projectile.
    /// </summary>
    /// <param name="other">The collider of the object collided with.</param>
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
