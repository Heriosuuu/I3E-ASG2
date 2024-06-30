/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Handles the triggering of the game win condition when the player enters the escape zone.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeZone : MonoBehaviour
{
    /// <summary>
    /// Triggered when another collider enters the trigger zone.
    /// </summary>
    /// <param name="other">The collider that entered the trigger zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger zone is the player
        if (other.CompareTag("Player"))
        {
            // Disable the PauseManager to prevent pausing after winning
            GameManager.Instance.GetComponent<PauseManager>().enabled = false;
            // Call the GameWin method from the GameManager
            GameManager.Instance.GameWin();
        }
    }
}
