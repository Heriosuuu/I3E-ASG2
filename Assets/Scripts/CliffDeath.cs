using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffDeath : MonoBehaviour
{
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
