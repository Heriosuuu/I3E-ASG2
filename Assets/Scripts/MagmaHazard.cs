using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaHazard : MonoBehaviour
{
    public float damagePerSecond = 30f;
    public float damageInterval = 1f; // Time interval for applying damage in seconds

    private float timer = 0f;
    private bool isInZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = false;
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
                ApplyDamage();
                timer = 0f; // Reset the timer after applying damage
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
            playerHealth.TakeDamage(20f);
        }
    }
}
