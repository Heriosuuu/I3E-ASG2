using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int ammo = 15;
    public TextMeshProUGUI scoreText;
    public bool haveEnergy = false; // Boolean to check if the player has the energy pod
    public GameObject inventoryEnergyPod; // Reference to the inventory UI element for the energy pod
    public GameObject player; // Reference to the player GameObject

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

    private void Start()
    {
        // Make sure the player also persists across scenes
        DontDestroyOnLoad(player);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // When the scene is loaded, set the player's position
        if (SpawnManager.Instance != null)
        {
            SpawnManager.Instance.SetPlayerPosition(player.transform);
        }
    }

    public void AddPoint(int ammoCount)
    {
        ammo += ammoCount;
        Debug.Log("Ammo: " + ammo);
        if (scoreText != null)
        {
            scoreText.text = "Ammo: " + ammo.ToString();
        }
    }

    public void EnableEnergyPodUI()
    {
        if (inventoryEnergyPod != null)
        {
            inventoryEnergyPod.SetActive(true); // Enable the inventory energy pod UI element
        }
    }

    public void GameWin()
    {
        Debug.Log("Game Won!");
    }
}
