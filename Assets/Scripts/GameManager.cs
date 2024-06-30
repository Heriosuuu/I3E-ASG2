/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Manages game state, player inventory, UI elements, and scene transitions.
 */
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// GameManager handles game state, player inventory, UI elements, and scene transitions.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int ammo = 15;
    public TextMeshProUGUI scoreText;
    public bool haveEnergy = false;
    public GameObject inventoryEnergyPod;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;
    public GameObject timeText; // Reference to the game object containing time text

    private GameObject player; // Reference to the player GameObject

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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /// <summary>
    /// Handles scene setup when a new scene is loaded.
    /// </summary>
    /// <param name="scene">The loaded scene.</param>
    /// <param name="mode">The load mode (single or additive).</param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Assign references to UI elements if they are missing
        if (scoreText == null)
        {
            scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        }

        if (inventoryEnergyPod == null)
        {
            inventoryEnergyPod = GameObject.FindGameObjectWithTag("InventoryEnergyPod");
        }

        if (gameOverPanel == null)
        {
            gameOverPanel = GameObject.FindGameObjectWithTag("GameOverPanel");
        }

        if (gameWinPanel == null)
        {
            gameWinPanel = GameObject.FindGameObjectWithTag("GameWinPanel");
        }

        if (scene.name == "MainMenu")
        {
            // Destroy all objects under DontDestroyOnLoad
            Destroy(Instance.gameObject);
            Instance = null;
            return; // Exit the method to avoid any null reference issues
        }

        if (scene.name == "Level 2")
        {
            timeText.SetActive(false);
        }

        if (scene.name == "Level 1")
        {
            timeText.SetActive(true);
        }
    }

    /// <summary>
    /// Adds ammunition points and updates the UI display.
    /// </summary>
    /// <param name="ammoCount">The amount of ammunition to add.</param>
    public void AddPoint(int ammoCount)
    {
        ammo += ammoCount;
        Debug.Log("Ammo: " + ammo);
        if (scoreText != null)
        {
            scoreText.text = "Ammo: " + ammo.ToString();
        }
    }

    /// <summary>
    /// Enables the UI display for the energy pod in the inventory.
    /// </summary>
    public void EnableEnergyPodUI()
    {
        if (inventoryEnergyPod != null)
        {
            inventoryEnergyPod.SetActive(true);
        }
    }

    /// <summary>
    /// Handles the game over state, pausing the game and displaying the game over panel.
    /// </summary>
    public void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// Handles the game win state, pausing the game and displaying the game win panel.
    /// </summary>
    public void GameWin()
    {
        Time.timeScale = 0f;
        gameWinPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// Called by PlayerHealth when the player's health reaches zero, triggering the game over state.
    /// </summary>
    public void PlayerHealthZero()
    {
        GameManager.Instance.GetComponent<PauseManager>().enabled = false;
        GameOver();
    }

    /// <summary>
    /// Sets the player reference for interaction purposes.
    /// </summary>
    /// <param name="playerObj">The GameObject representing the player.</param>
    public void SetPlayer(GameObject playerObj)
    {
        player = playerObj;
    }
}
