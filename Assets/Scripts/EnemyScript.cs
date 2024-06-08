using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Enemy stats
    public int health;
    public int maxHealth;

    // Reference to the enemy's health bar (if any)
    public HealthBar healthBar;

    // Reference to the health bar GameObject for positioning
    public GameObject healthBarObject;

    private void Start()
    {
        // Initialize health
        health = maxHealth;

        // Update health bar if exists
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    private void Update()
    {
        // Update health bar position
        if (healthBarObject != null)
        {
            healthBarObject.transform.position = transform.position + new Vector3(0, 2, 0); // Adjust the offset as needed
            healthBarObject.transform.LookAt(Camera.main.transform); // Make the health bar face the camera
        }
    }

    public void TakeDamage(int damageAmount)
    {
        // Reduce health by damage amount
        health -= damageAmount;

        // Update health bar if exists
        if (healthBar != null)
        {
            healthBar.SetHealth(health);
        }

        // Check if health is less than or equal to 0
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle enemy death here (e.g., play animation, disable enemy, etc.)
        Debug.Log(gameObject.name + " died.");

        // Destroy the enemy game object
        Destroy(gameObject);
    }
}
