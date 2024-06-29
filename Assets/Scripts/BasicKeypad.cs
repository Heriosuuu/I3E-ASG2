using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicKeypad : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;

    public AudioClip doorSound; // The sound clip to play when the door opens/closes

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
