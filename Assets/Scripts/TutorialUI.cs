/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Manages the activation and deactivation of a tutorial UI when a player enters and exits a trigger zone.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject tutorialUI; // Reference to the Tutorial UI GameObject

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tutorialUI.SetActive(true); // Enable the Tutorial UI GameObject
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tutorialUI.SetActive(false); // Disable the Tutorial UI GameObject if needed
        }
    }
}
