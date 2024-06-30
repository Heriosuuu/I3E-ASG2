/*
* Author: Malcom Goh
* Date: 30/6/2024
* Description: Represents a collectible item that can be picked up by the player, providing various interactions and effects upon collection.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : Interactable
{
    [SerializeField]
    private AudioClip collectAudio;

    public int ammo = 15;

    /// <summary>
    /// Updates the player's interaction state with this collectible.
    /// </summary>
    /// <param name="player">The player interacting with the collectible.</param>
    public void UpdatePlayerInteractable(Player player)
    {
        player.UpdateCollectible(this);
    }

    /// <summary>
    /// Removes the player's interaction state with this collectible.
    /// </summary>
    /// <param name="player">The player to remove interaction from.</param>
    public void RemovePlayerInteractable(Player player)
    {
        player.UpdateCollectible(null);
    }

    /// <summary>
    /// Handles the collection logic when the collectible is picked up by the player.
    /// </summary>
    /// <param name="player">The player collecting the collectible.</param>
    public virtual void Collected(Player player)
    {
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
        Debug.Log("collected");
        GameManager.Instance.AddPoint(ammo); // Add ammo points to the player's score
        Destroy(gameObject); // Destroy the collectible object after collection
    }
}
