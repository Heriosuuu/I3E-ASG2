/*
* Author: Malcom Goh
* Date: 30/6/2024
* Description: This script handles the Area of Effect (AOE) visual effect by playing an animation and then destroying the GameObject after a specified time.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEEffect : MonoBehaviour
{
    // Animator component to control animations
    private Animator animator;

    // Time after which the GameObject will be destroyed
    public float destroyAfter = 1.5f;

    /// <summary>
    /// Initializes the animator component
    /// </summary>
    private void Awake()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Plays the "Enlarge" animation and starts the coroutine to destroy the GameObject after a specified time
    /// </summary>
    private void Start()
    {
        // Play the "Enlarge" animation
        animator.Play("Enlarge");

        // Start the coroutine to destroy the GameObject after 'destroyAfter' seconds
        StartCoroutine(DestroyAfterTime(destroyAfter));
    }

    /// <summary>
    /// Waits for a specified amount of time and then destroys the GameObject
    /// </summary>
    /// <param name="time">The time to wait before destroying the GameObject</param>
    private IEnumerator DestroyAfterTime(float time)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(time);

        // Destroy the GameObject
        Destroy(gameObject);
    }
}
