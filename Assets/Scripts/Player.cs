using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    Collectible collectible;
    Giftbox giftbox;
    Keypad keypad;

    [SerializeField]
    Transform playerCamera;

    [SerializeField]
    float interactionDistance;

    [SerializeField]
    TextMeshProUGUI interactText;

    [SerializeField]
    KeyCode interactKey = KeyCode.E;

    public void UpdateCollectible(Collectible newCollectible)
    {
        collectible = newCollectible;
    }

    void OnInteract()
    {
        if (collectible != null)
        {
            collectible.Collected(this);
            collectible = null;
        }

        if (giftbox != null)
        {
            giftbox.Interact();
            giftbox = null;
        }

        if (keypad != null)
        {
            keypad.Interact();
            keypad = null;
        }
    }

    public void Update()
    {
        Debug.DrawLine(transform.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            if (hitInfo.transform.TryGetComponent<Collectible>(out collectible))
            {
                // Interact text
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else if (hitInfo.transform.TryGetComponent<Giftbox>(out giftbox))
            {
                // Interact text
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }

            else if (hitInfo.transform.TryGetComponent<Keypad>(out keypad))
            {
                // Interact text
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }

            else
            {
                collectible = null;
                giftbox = null;
                keypad = null;
                interactText.gameObject.SetActive(false);
            }
        }
        else
        {
            collectible = null;
            giftbox = null;
            keypad = null;
            interactText.gameObject.SetActive(false);
        }
    }
}