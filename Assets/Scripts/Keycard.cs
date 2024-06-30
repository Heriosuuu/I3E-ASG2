/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Represents a keycard that can be picked up by the player, enabling interactions and effects upon collection.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : Interactable
{
    public AudioClip pickupSound; // Sound clip for picking up the keycard
    public GameObject Obj2; // Reference to another GameObject to deactivate upon pickup

    /// <summary>
    /// Method called when the keycard is picked up by the player.
    /// </summary>
    /// <param name="player">The player object picking up the keycard.</param>
    public void PickupKeycard(Player player)
    {
        player.hasKeycard = true; // Set the player's keycard field to true
        Destroy(gameObject); // Destroy the keycard object after pickup
        Obj2.SetActive(false); // Deactivate another GameObject upon keycard pickup

        // Play pickup sound if available
        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position, 1f);
        }
    }
}
