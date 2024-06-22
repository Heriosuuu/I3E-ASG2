using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int ammo = 15;

    public TextMeshProUGUI scoreText;

    public bool haveEnergy = false; // Boolean to check if the player has the energy pod
    public GameObject inventoryEnergyPod; // Reference to the inventory UI element for the energy pod

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void AddPoint(int ammoCount)
    {
        ammo += ammoCount;
        Debug.Log("Ammo: " + ammo );
        scoreText.text = "Ammo: " + ammo.ToString();
    }

    public void EnableEnergyPodUI()
    {
        inventoryEnergyPod.SetActive(true); // Enable the inventory energy pod UI element
    }

    public void GameWin()
    {
        
        Debug.Log("Game Won!");
        
    }
}
