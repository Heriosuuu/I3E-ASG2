/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Controls the activation and deactivation of a TextMeshPro text element when a player enters and exits a trigger zone.
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIContact : MonoBehaviour
{
    public TextMeshProUGUI messageText; // Reference to the TextMeshPro text element

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (messageText != null)
            {
                messageText.gameObject.SetActive(true);  // Enable the text element
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (messageText != null)
            {
                messageText.gameObject.SetActive(false);  // Disable the text element
            }
        }
    }
}
