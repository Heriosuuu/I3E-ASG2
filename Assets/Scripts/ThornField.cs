using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornField : MonoBehaviour
{
    public float damagePerSecond = 5f;
    public float damageInterval = 1f; // Time interval for applying damage in seconds
    public float slowdownFactor = 0.5f; // Factor by which the player's speed is reduced

    private float timer = 0f;
    private bool isInZone = false;
    private FirstPersonController firstPersonController; // Cache for FirstPersonController component
    private float originalMoveSpeed; // Cache for the original player speed

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = true;
            firstPersonController = other.GetComponent<FirstPersonController>(); // Cache the FirstPersonController component
            originalMoveSpeed = firstPersonController.MoveSpeed; // Cache the original player speed
        }
    }

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
