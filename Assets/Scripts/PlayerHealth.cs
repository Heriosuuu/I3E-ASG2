/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: PlayerHealth handles the player's health management, updating the health UI, taking damage, and restoring health. It includes features such as a health bar with front and back components, damage overlay effects, and sound feedback for damage taken and health restored.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;

    [Header("Health Bar")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHp;
    public Image backHp;

    [Header("Damage")]
    public Image overlay;
    public float duration;
    public float fadeSpd;
    public AudioClip damageSound; // Sound clip for taking damage

    private float durationTimer;

    private GameManager gameManager; // Reference to GameManager

    void Start()
    {
        // Initialize health and references
        health = 100;
        gameManager = GameManager.Instance;
        gameManager.SetPlayer(gameObject);
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0f);
    }

    void Update()
    {
        // Updates the health UI and manages the damage overlay fading
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        // Fade out the damage overlay if health is above a threshold
        if (overlay.color.a > 0)
        {
            if (health < 30)
            {
                return;
            }

            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpd;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }

    /// <summary>
    /// Updates the visual representation of the player's health on the UI.
    /// </summary>
    public void UpdateHealthUI()
    {
        float fillF = frontHp.fillAmount;
        float fillB = backHp.fillAmount;
        float hFraction = health / maxHealth;

        if (fillB > hFraction)
        {
            frontHp.fillAmount = hFraction;
            backHp.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHp.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }

        if (fillF < hFraction)
        {
            backHp.color = Color.green;
            backHp.fillAmount = hFraction;
            lerpTimer -= Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHp.fillAmount = Mathf.Lerp(fillF, backHp.fillAmount, percentComplete);
        }
    }

    /// <summary>
    /// Inflicts damage to the player's health and updates the UI and game state accordingly.
    /// </summary>
    /// <param name="damage">The amount of damage to inflict.</param>
    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        if (health <= 0)
        {
            health = 0;
            gameManager.PlayerHealthZero();
        }

        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1f);

        durationTimer = 0f; // Reset the duration timer
        UpdateHealthUI();

        AudioSource.PlayClipAtPoint(damageSound, transform.position, 1f);
    }

    /// <summary>
    /// Restores the player's health by the specified amount, up to the maximum health.
    /// </summary>
    /// <param name="healAmount">The amount of health to restore.</param>
    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthUI();

        AudioSource.PlayClipAtPoint(damageSound, transform.position, 1f);
    }
}
