/*
* Author: Malcom Goh
* Date: 30/6/2024
* Description: This script handles the interaction with a basic keypad that opens and closes a door with an animation and sound effect.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicKeypad : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;

    public AudioClip doorSound; // The sound clip to play when the door opens/closes

    /// <summary>
    /// Handles the interaction with the keypad, toggling the door open state and playing the door sound.
    /// </summary>
    public void Interact()
    {
        AudioSource.PlayClipAtPoint(doorSound, transform.position, 1f);
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("isOpen", doorOpen);

        if (doorOpen)
        {
            StartCoroutine(CloseDoorAfterDelay(3f)); // Start the coroutine to close the door after 3 seconds
        }
    }

    /// <summary>
    /// Coroutine to close the door after a specified delay.
    /// </summary>
    /// <param name="delay">The delay in seconds before the door closes.</param>
    private IEnumerator CloseDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        doorOpen = false;
        door.GetComponent<Animator>().SetBool("isOpen", doorOpen);

        // Play the door sound again when it closes
        if (doorSound != null)
        {
            AudioSource.PlayClipAtPoint(doorSound, transform.position, 1f);
        }
    }
}
