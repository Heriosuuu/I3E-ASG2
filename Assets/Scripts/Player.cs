using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
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

    public void UpdateCollectible(Collectible newCollectible)
    {
        collectible = newCollectible;
    }

    public void UpdateMedkit(Medkit newMedkit)
    {
        medkit = newMedkit;
    }

    void OnInteract()
    {
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
        else if (basicKeypad != null) // Add interaction with BasicKeypad
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
        else if (keycard != null) // Add keycard interaction
        {
            keycard.PickupKeycard(this);
            keycard = null;
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
            else if (hitInfo.transform.TryGetComponent<BasicKeypad>(out basicKeypad)) // Add detection for BasicKeypad
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
            else if (hitInfo.transform.TryGetComponent<Keycard>(out keycard)) // Add keycard detection
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

    public void EnableGun()
    {
        gun.SetActive(true);
        ammo.SetActive(true);
    }
}
