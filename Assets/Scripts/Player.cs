/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Script controlling player interactions, health, inventory, and interactions with various game objects.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the player's interactions, health, and inventory management.
/// </summary>
public class Player : MonoBehaviour
{
    // Variables for interacting with different game objects
    Collectible collectible;
    Giftbox giftbox;
    Keypad keypad;
    BasicKeypad basicKeypad;
    GunPickup gunPickup;
    EnergyPickUp energyPodPickup;
    EscapePod escapePod;
    Medkit medkit;
    Keycard keycard;

    [SerializeField] Transform playerCamera;
    [SerializeField] float interactionDistance;
    [SerializeField] TextMeshProUGUI interactText;
    [SerializeField] KeyCode interactKey = KeyCode.E;
    public GameObject gun;
    public GameObject ammo;

    // Health variables
    public int maxHealth = 100;
    private int currentHealth;

    public bool hasKeycard; // Public field to track if the player has a keycard

    private void Start()
    {
        // Initialize other variables and game state
        currentHealth = maxHealth;
        gun.SetActive(false);
        ammo.SetActive(false);

        GameManager.Instance.inventoryEnergyPod.SetActive(false);
        hasKeycard = false;
    }

    /// <summary>
    /// Updates the current collectible item that the player can interact with.
    /// </summary>
    /// <param name="newCollectible">The new collectible item to update.</param>
    public void UpdateCollectible(Collectible newCollectible)
    {
        collectible = newCollectible;
    }

    /// <summary>
    /// Updates the current medkit item that the player can interact with.
    /// </summary>
    /// <param name="newMedkit">The new medkit item to update.</param>
    public void UpdateMedkit(Medkit newMedkit)
    {
        medkit = newMedkit;
    }

    /// <summary>
    /// Handles the interaction when the player interacts with an object.
    /// </summary>
    void OnInteract()
    {
        // Check which object the player is interacting with and perform corresponding actions
        if (collectible != null)
        {
            collectible.Collected(this);
            collectible = null;
        }
        else if (medkit != null)
        {
            medkit.Collected(this);
            medkit = null;
        }
        else if (giftbox != null)
        {
            giftbox.Interact();
            giftbox = null;
        }
        else if (keypad != null)
        {
            keypad.Interact();
            keypad = null;
        }
        else if (basicKeypad != null)
        {
            basicKeypad.Interact();
            basicKeypad = null;
        }
        else if (gunPickup != null)
        {
            gunPickup.PickupGun(this);
            gunPickup = null;
        }
        else if (energyPodPickup != null)
        {
            energyPodPickup.PickupEnergyPod();
            energyPodPickup = null;
        }
        else if (escapePod != null)
        {
            if (GameManager.Instance.haveEnergy)
            {
                escapePod.ActivateEnergyPod();
                GameManager.Instance.haveEnergy = false;
            }
            else if (escapePod.energyPod.activeSelf)
            {
                GameManager.Instance.GameWin();
            }
            else
            {
                escapePod.EnableHintText();
            }
        }
        else if (keycard != null)
        {
            keycard.PickupKeycard(this);
            keycard = null;
        }
    }

    /// <summary>
    /// Updates every frame to check for interactions within the player's interaction distance.
    /// </summary>
    public void Update()
    {
        Debug.DrawLine(transform.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
        RaycastHit hitInfo;

        // Raycast to detect objects within interaction distance
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            // Check if the hit object has any of the interactable components and interact accordingly
            if (hitInfo.transform.TryGetComponent<Collectible>(out collectible))
            {
                interactText.text = collectible.interactionText;
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else if (hitInfo.transform.TryGetComponent<Giftbox>(out giftbox))
            {
                interactText.text = giftbox.interactionText;
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else if (hitInfo.transform.TryGetComponent<Keypad>(out keypad))
            {
                interactText.text = keypad.interactionText;
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else if (hitInfo.transform.TryGetComponent<BasicKeypad>(out basicKeypad))
            {
                interactText.text = basicKeypad.interactionText;
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else if (hitInfo.transform.TryGetComponent<GunPickup>(out gunPickup))
            {
                interactText.text = gunPickup.interactionText;
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else if (hitInfo.transform.TryGetComponent<EnergyPickUp>(out energyPodPickup))
            {
                interactText.text = energyPodPickup.interactionText;
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else if (hitInfo.transform.TryGetComponent<EscapePod>(out escapePod))
            {
                interactText.text = escapePod.interactionText;
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else if (hitInfo.transform.TryGetComponent<Medkit>(out medkit))
            {
                interactText.text = medkit.interactionText;
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else if (hitInfo.transform.TryGetComponent<Keycard>(out keycard))
            {
                interactText.text = keycard.interactionText;
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(interactKey))
                {
                    OnInteract();
                }
            }
            else
            {
                // Reset interactable objects and hide interaction text if no valid interaction detected
                collectible = null;
                giftbox = null;
                keypad = null;
                basicKeypad = null;
                gunPickup = null;
                energyPodPickup = null;
                escapePod = null;
                medkit = null;
                keycard = null;
                interactText.gameObject.SetActive(false);
            }
        }
        else
        {
            // Reset interactable objects and hide interaction text if no valid interaction detected
            collectible = null;
            giftbox = null;
            keypad = null;
            basicKeypad = null;
            gunPickup = null;
            energyPodPickup = null;
            escapePod = null;
            medkit = null;
            keycard = null;
            interactText.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Enables the player's gun and ammo when the player picks up a gun.
    /// </summary>
    public void EnableGun()
    {
        gun.SetActive(true);
        ammo.SetActive(true);
    }
}
