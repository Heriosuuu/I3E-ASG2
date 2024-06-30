/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Represents an interactable keypad that controls a door's opening and closing based on the player's possession of a keycard.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private GameObject door; // Reference to the door GameObject controlled by the keypad
    private bool doorOpen; // Flag to track if the door is open or closed

    public AudioClip doorSound; // Sound clip to play when the door opens/closes

    private Player player; // Reference to the Player script

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); // Find and assign the Player component
    }

    /// <summary>
    /// Method called when the player interacts with the keypad.
    /// </summary>
    public void Interact()
    {
        if (player.hasKeycard) // Check if the player has a keycard
        {
            doorOpen = !doorOpen; // Toggle the doorOpen flag
            door.GetComponent<Animator>().SetBool("isOpen", doorOpen); // Set the "isOpen" parameter of the door's Animator

            // Play the door sound if available
            if (doorSound != null)
            {
                AudioSource.PlayClipAtPoint(doorSound, transform.position, 1f);
            }
        }
        else
        {
            Debug.Log("You need a keycard to use this keypad."); // Print message if player doesn't have a keycard
        }
    }
}
