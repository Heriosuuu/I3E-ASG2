using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIContact : MonoBehaviour
{
    public TextMeshProUGUI messageText;

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
