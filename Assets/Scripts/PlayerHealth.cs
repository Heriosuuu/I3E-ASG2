using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private float health;
    private float lerpTimer;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHp;
    public Image backHp;

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


        if (Input.GetKeyUp(KeyCode.L))
        {
            TakeDamage(Random.Range(20, 30));
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            RestoreHealth(10);
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log(health);
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
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
    }
}
