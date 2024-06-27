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
        health = 100;
        gameManager = GameManager.Instance; // Get GameManager instance
        gameManager.SetPlayer(gameObject); // Set player reference in GameManager
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0f);
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        

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
    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        if (health <= 0)
        {
            health = 0;
            // Notify GameManager that player health is zero
            gameManager.PlayerHealthZero();
        }
        UpdateHealthUI();

        // Play damage sound
        AudioSource.PlayClipAtPoint(damageSound, transform.position, 1f);
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthUI();

        AudioSource.PlayClipAtPoint(damageSound, transform.position, 1f);
    }
}