using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    private Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;

    private float lerpTimer;

    [Header("Health Bar")]
    public float maxHealth = 60f;
    public float chipSpeed = 2f;
    public Image frontHp;
    public Image backHp;

    [Header("Damage")]
    public float duration;
    public float fadeSpd;

    [Header("Attack")]
    public float sightRange = 10f; // Adjust as needed
    public float attackRange = 5f; // Adjust as needed
    public float timeBetweenAttacks = 3f;
    private bool playerInSightRange, playerInAttackRange;
    private bool alreadyAttacked;

    [Header("Projectile")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 20f;
    public float aimHeightOffset = 2f; // New variable to control the height offset of the aim

    [Header("Audio")]
    public AudioClip destructionSound; // Sound played when the enemy is destroyed

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        health = maxHealth;
    }

    private void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }

        // Always face the player
        transform.LookAt(player);
    }

    public void UpdateHealthUI()
    {
        float hFraction = health / maxHealth;

        // Update health bar visuals
        frontHp.fillAmount = hFraction;

        // Smoothly update the back health bar
        backHp.fillAmount = Mathf.Lerp(backHp.fillAmount, hFraction, Time.deltaTime * chipSpeed);

        // Change color based on health status
        if (health <= 0)
        {
            frontHp.color = Color.red; // Change front health bar color to red
        }
        else
        {
            frontHp.color = Color.green; // Default color for healthy state
        }
    }

    private void Patroling()
    {
        // Implement patrol logic here if needed
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        // Stop moving towards the player
        agent.SetDestination(transform.position);

        // Rotate to face the player
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // Attack code here
            ShootProjectile();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ShootProjectile()
    {
        // Instantiate a projectile at the enemy's position
        GameObject spawnedProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Calculate direction towards the player's upper body
        Vector3 direction = (player.position + Vector3.up * aimHeightOffset - transform.position).normalized;

        // Get the Rigidbody component and set velocity
        Rigidbody rb = spawnedProjectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;

        if (health <= 0)
        {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy()
    {
        // Play destruction sound if defined
        if (destructionSound != null)
        {
            AudioSource.PlayClipAtPoint(destructionSound, transform.position, 1f);
        }

        // Destroy the enemy GameObject
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw attack and sight ranges for debugging
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
