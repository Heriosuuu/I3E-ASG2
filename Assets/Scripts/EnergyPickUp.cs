/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Handles the interaction logic for picking up an energy pod in the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickUp : Interactable
{
    public AudioSource pickupAudioSource; // Reference to the AudioSource
    public AudioClip pickupSound; // The sound clip to play when picking up the energy pod
    public GameObject obj2; // Reference to another GameObject to deactivate upon pickup
    public GameObject energypodTrue; // Reference to enable upon pickup

    /// <summary>
    /// Handles the pickup logic for the energy pod.
    /// </summary>
    public void PickupEnergyPod()
    {
        GameManager.Instance.haveEnergy = true; // Set the GameManager's energy state to true
        obj2.SetActive(false); // Deactivate obj2 GameObject
        energypodTrue.SetActive(true); // Activate energypodTrue GameObject

        // Play pickup sound if both audio source and sound clip are defined
        if (pickupAudioSource != null && pickupSound != null)
        {
            pickupAudioSource.PlayOneShot(pickupSound);
        }

        Destroy(gameObject); // Destroy the pickup object after pickup
    }
}
