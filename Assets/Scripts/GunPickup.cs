using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : Interactable
{
    public GameObject gun; // Reference to the gun GameObject to be enabled on the player
    public AudioClip pickupSound; // Sound clip for picking up the gun

    public void PickupGun(Player player)
    {
        player.EnableGun();
        Destroy(gameObject); // Destroy the pickup object after pickup

        // Play pickup sound
        AudioSource.PlayClipAtPoint(pickupSound, transform.position, 1f);
    }
}
