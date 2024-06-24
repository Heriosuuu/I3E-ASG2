using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

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

    private float durationTimer;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
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
    }

    public void Damage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
    }


}
