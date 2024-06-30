using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickUp : Interactable
{
    public AudioSource pickupAudioSource; // Reference to the AudioSource
    public AudioClip pickupSound; // The sound clip to play when picking up the gun
    public GameObject obj2;
    public GameObject energypodTrue;
    public void PickupEnergyPod()
    {
        GameManager.Instance.haveEnergy = true;
        obj2.SetActive(false);
        energypodTrue.SetActive(true);

        if (pickupAudioSource != null && pickupSound != null)
        {
            pickupAudioSource.PlayOneShot(pickupSound);
        }

        Destroy(gameObject); // Destroy the pickup object after pickup
    }
}
