using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;

    public AudioClip doorSound; // The sound clip to play when the door opens/closes

    public void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("isOpen", doorOpen);

        // Play the door sound
        if (doorSound != null)
        {
            AudioSource.PlayClipAtPoint(doorSound, transform.position, 1f);
        }
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
