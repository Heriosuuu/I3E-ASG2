/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Represents an interactable object that, when picked up by the player, enables a specified gun GameObject on the player.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : Interactable
{
    public GameObject gun; // Reference to the gun GameObject to be enabled on the player
    public AudioClip pickupSound; // Sound clip for picking up the gun

    /// <summary>
    /// Enables the specified gun on the player and plays a pickup sound.
    /// </summary>
    /// <param name="player">The Player instance to enable the gun on.</param>
    public void PickupGun(Player player)
    {
        player.EnableGun(); // Enable the gun on the player
        Destroy(gameObject); // Destroy the pickup object after pickup

        // Play pickup sound
        AudioSource.PlayClipAtPoint(pickupSound, transform.position, 1f);
    }
}
