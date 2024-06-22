using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

public class Player : MonoBehaviour
{
    Collectible collectible;
    Giftbox giftbox;
    Keypad keypad;
    GunPickup gunPickup;
    EnergyPickUp energyPodPickup;
    EscapePod escapePod;

    [SerializeField]
    Transform playerCamera;

    [SerializeField]
    float interactionDistance;

    [SerializeField]
    TextMeshProUGUI interactText;

    [SerializeField]
    KeyCode interactKey = KeyCode.E;

    public GameObject gun; // Reference to the gun GameObject on the player
    public GameObject ammo; // Reference to the ammo GameObject on the player

    private void Start()
    {
        gun.SetActive(false);
        ammo.SetActive(false); // Initially hide the ammo GameObject
        GameManager.Instance.inventoryEnergyPod.SetActive(false); // Initially hide the inventory energy pod UI element
    }

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

        if (gunPickup != null)
        {
            gunPickup.PickupGun(this);
            gunPickup = null;
        }

        if (energyPodPickup != null)
        {
            energyPodPickup.PickupEnergyPod();
            energyPodPickup = null;
        }

        if (escapePod != null)
        {
            if (GameManager.Instance.haveEnergy)
            {
                escapePod.ActivateEnergyPod();
                GameManager.Instance.haveEnergy = false;
            }
            else if (escapePod.energyPod.activeSelf) // Check if the energy pod is active on the escape pod
            {
                GameManager.Instance.GameWin();
            }
            else
            {
                escapePod.EnableHintText(); // Enable the hint text on the escape pod
            }
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
                interactText.text = collectible.interactionText; // Use the specific interaction text
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else if (hitInfo.transform.TryGetComponent<Giftbox>(out giftbox))
            {
                // Interact text
                interactText.text = giftbox.interactionText; // Use the specific interaction text
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else if (hitInfo.transform.TryGetComponent<Keypad>(out keypad))
            {
                // Interact text
                interactText.text = keypad.interactionText; // Use the specific interaction text
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else if (hitInfo.transform.TryGetComponent<GunPickup>(out gunPickup))
            {
                // Interact text
                interactText.text = gunPickup.interactionText; // Use the specific interaction text
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else if (hitInfo.transform.TryGetComponent<EnergyPickUp>(out energyPodPickup))
            {
                // Interact text
                interactText.text = energyPodPickup.interactionText; // Use the specific interaction text
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else if (hitInfo.transform.TryGetComponent<EscapePod>(out escapePod))
            {
                // Interact text
                interactText.text = escapePod.interactionText; // Use the specific interaction text
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
                gunPickup = null;
                energyPodPickup = null;
                escapePod = null;
                interactText.gameObject.SetActive(false);
            }
        }
        else
        {
            collectible = null;
            giftbox = null;
            keypad = null;
            gunPickup = null;
            energyPodPickup = null;
            escapePod = null;
            interactText.gameObject.SetActive(false);
        }
    }

    public void EnableGun()
    {
        gun.SetActive(true);
        ammo.SetActive(true); // Enable the ammo GameObject
    }
}