using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 2f;
    public float damage = 20f;
    public GameObject impactEffect; // A GameObject to instantiate for the AOE effect

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

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

    void SpawnAOE()
    {
        Instantiate(impactEffect, transform.position, impactEffect.transform.rotation);
    }

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
