using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEEffect : MonoBehaviour
{
    public float damage = 5f;
    public float duration = 5f;
    private float timer;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.Play("Enlarge");
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.name == "PlayerCapsule")
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage((int)damage);
            }
        }
        else if (other.gameObject.name == "Enemy")
        {
           
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage((int)damage);
            }
        }
    }
}

