/*
* Author: Malcom Goh
* Date: 30/6/2024
* Description: This script handles the behavior of a bullet, including its movement, collision detection, and interaction with enemies and walls.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 2f;
    public float damage = 20f;
    public GameObject impactEffect; // A GameObject to instantiate for the AOE effect

    /// <summary>
    /// Initializes the bullet by setting it to be destroyed after a specified lifetime.
    /// </summary>
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    /// <summary>
    /// Moves the bullet forward each frame based on its speed.
    /// </summary>
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    /// <summary>
    /// Handles the collision detection and interaction with enemies and walls.
    /// </summary>
    /// <param name="other">The collider of the other GameObject.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collides with an enemy by name
        if (other.gameObject.name == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Reduce the enemy's health
                enemy.TakeDamage((int)damage);
            }
            SpawnAOE();
            // Destroy the bullet upon collision with the enemy
            DestroyBullet();
        }
        // Check if the bullet collides with an object tagged as "Wall"
        else if (other.CompareTag("Wall"))
        {
            SpawnAOE();
            // Destroy the bullet upon collision with a wall
            DestroyBullet();
        }
    }

    /// <summary>
    /// Instantiates the AOE effect at the bullet's position.
    /// </summary>
    void SpawnAOE()
    {
        Instantiate(impactEffect, transform.position, impactEffect.transform.rotation);
    }

    /// <summary>
    /// Destroys the bullet and spawns an impact effect if specified.
    /// </summary>
    private void DestroyBullet()
    {
        // Instantiate an impact effect at the bullet's position
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }

        // Destroy the bullet
        Destroy(gameObject);
    }
}
