using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : Interactable
{
    public AudioClip pickupSound; // Sound clip for picking up the keycard

    public void PickupKeycard(Player player)
    {
        player.hasKeycard = true; // Set the player's keycard field to true
        Destroy(gameObject); // Destroy the keycard object after pickup

        // Play pickup sound
        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position, 1f);
        }
    }
}
