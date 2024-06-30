/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Handles the thorn field functionality, applying damage over time to the player and slowing their movement speed.
 */

using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornField : MonoBehaviour
{
    /// <summary>
    /// Damage per second applied to the player while inside the thorn field.
    /// </summary>
    public float damagePerSecond = 5f;

    /// <summary>
    /// Time interval in seconds between each application of damage.
    /// </summary>
    public float damageInterval = 1f;

    /// <summary>
    /// Factor by which the player's movement speed is reduced while inside the thorn field.
    /// </summary>
    public float slowdownFactor = 0.5f;

    private float timer = 0f;
    private bool isInZone = false;
    private FirstPersonController firstPersonController; // Cache for FirstPersonController component
    private float originalMoveSpeed; // Cache for the original player speed

    /// <summary>
    /// Activates when a collider enters the thorn field zone, setting the player to be affected.
    /// </summary>
    /// <param name="other">The collider that enters the trigger zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = true;
            firstPersonController = other.GetComponent<FirstPersonController>(); // Cache the FirstPersonController component
            originalMoveSpeed = firstPersonController.MoveSpeed; // Cache the original player speed
        }
    }

    /// <summary>
    /// Deactivates when a collider exits the thorn field zone, stopping the player from being affected.
    /// </summary>
    /// <param name="other">The collider that exits the trigger zone.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = false;
            if (firstPersonController != null)
            {
                // Restore the player's speed to its original value
                firstPersonController.MoveSpeed = originalMoveSpeed;
            }
            firstPersonController = null; // Reset the cached FirstPersonController component
            timer = 0f; // Reset the timer when the player exits the zone
        }
    }

    /// <summary>
    /// Update is called once per frame. Applies damage over time to the player while inside the thorn field.
    /// </summary>
    private void Update()
    {
        if (isInZone)
        {
            timer += Time.deltaTime;
            if (timer >= damageInterval)
            {
                ApplyDamageAndSlowdown();
                timer -= damageInterval; // Subtract the interval to avoid accumulating error
            }
        }
    }

    /// <summary>
    /// Applies damage to the player and slows down their movement speed while inside the thorn field.
    /// </summary>
    private void ApplyDamageAndSlowdown()
    {
        if (firstPersonController != null)
        {
            // Apply damage to the player
            PlayerHealth playerHealth = firstPersonController.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damagePerSecond);
            }

            // Slow down the player
            firstPersonController.MoveSpeed *= slowdownFactor;
        }
    }
}
