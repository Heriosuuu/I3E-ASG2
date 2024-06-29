using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
            inventoryEnergyPod.SetActive(true);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void GameWin()
    {
        Time.timeScale = 0f;
        gameWinPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Method called by PlayerHealth when health reaches zero
    public void PlayerHealthZero()
    {
        GameManager.Instance.GetComponent<PauseManager>().enabled = false;
        GameOver();
    }

    // Method to set player reference (called from PlayerHealth script)
    public void SetPlayer(GameObject playerObj)
    {
        player = playerObj;
    }
}
