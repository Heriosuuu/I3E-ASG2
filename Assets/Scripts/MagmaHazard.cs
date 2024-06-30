/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Represents a hazardous area that damages the player over time while they are inside the zone.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaHazard : MonoBehaviour
{
    public float damagePerSecond = 30f; // Amount of damage applied per second
    public float damageInterval = 1f; // Time interval for applying damage in seconds

    private float timer = 0f; // Timer to track damage intervals
    private bool isInZone = false; // Flag to indicate if the player is inside the hazard zone

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = true; // Player enters the hazard zone
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = false; // Player exits the hazard zone
            timer = 0f; // Reset the damage timer
        }
    }

    private void Update()
    {
        if (isInZone)
        {
            timer += Time.deltaTime; // Increment timer based on real-time seconds
            if (timer >= damageInterval)
            {
                ApplyDamage(); // Apply damage after each damage interval
                timer = 0f; // Reset timer for the next interval
            }
        }
    }

    private void ApplyDamage()
    {
        // Get the PlayerHealth component from the player GameObject
        PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            // Apply damage to the player
            playerHealth.TakeDamage(damagePerSecond * damageInterval);
        }
    }
}
