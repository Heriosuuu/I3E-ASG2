/*
* Author: Malcom Goh
* Date: 30/6/2024
* Description: This script handles the behavior of triggering death for the player when they fall off a cliff.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffDeath : MonoBehaviour
{
    /// <summary>
    /// Triggers player death when they fall off a cliff by setting their health to zero.
    /// </summary>
    /// <param name="other">The collider of the other GameObject.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(playerHealth.maxHealth); // Set health to 0 by dealing max damage
            }
        }
    }
}
