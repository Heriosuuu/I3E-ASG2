/*
* Author: Malcom Goh
* Date: 30/6/2024
* Description: This script handles applying Area of Effect (AOE) damage to enemies over a specified duration.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEDamage : MonoBehaviour
{
    public float damage = 5f;
    public float duration = 5f;
    private float timer;

    /// <summary>
    /// Updates the timer and destroys the GameObject when the duration is reached
    /// </summary>
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Handles collision with enemies and applies damage
    /// </summary>
    /// <param name="other">The collider of the other GameObject</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Enemy")
        {
            Debug.Log("Contact enemy aoe");
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
