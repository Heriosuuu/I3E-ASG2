using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;

    public AudioClip doorSound; // The sound clip to play when the door opens/closes

    private Player player; // Reference to the Player script

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void Interact()
    {
        if (player.hasKeycard) 
        {
            doorOpen = !doorOpen;
            door.GetComponent<Animator>().SetBool("isOpen", doorOpen);

            // Play the door sound
            if (doorSound != null)
            {
                AudioSource.PlayClipAtPoint(doorSound, transform.position, 1f);
            }
        }
        else
        {
            Debug.Log("You need a keycard to use this keypad.");
        }
    }

    

    private void Update()
    {

    }
}
