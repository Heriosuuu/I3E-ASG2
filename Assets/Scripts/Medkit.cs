/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Represents a medkit that can be collected by the player, restoring health upon collection.
 */

using UnityEngine;

public class Medkit : Interactable
{
    [SerializeField]
    private AudioClip collectAudio; // Sound clip for collecting the medkit

    public int heal = 20; // Amount of health restored by the medkit

    /// <summary>
    /// Update the player's interactable item to this medkit.
    /// </summary>
    /// <param name="player">The player interacting with the medkit.</param>
    public void UpdatePlayerInteractable(Player player)
    {
        player.UpdateMedkit(this);
    }

    /// <summary>
    /// Remove the player's interactable item.
    /// </summary>
    /// <param name="player">The player whose interactable item is being removed.</param>
    public void RemovePlayerInteractable(Player player)
    {
        player.UpdateMedkit(null);
    }

    /// <summary>
    /// Perform actions when the medkit is collected by the player.
    /// </summary>
    /// <param name="player">The player collecting the medkit.</param>
    public virtual void Collected(Player player)
    {
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f); // Play collection sound
        Destroy(gameObject); // Destroy the medkit object
        Debug.Log("Heal"); // Log healing action (for debugging)
        player.GetComponent<PlayerHealth>().RestoreHealth(heal); // Restore player health
    }
}
