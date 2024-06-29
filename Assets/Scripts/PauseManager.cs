using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu UI GameObject
    public GameObject optionsMenuUI; // Reference to the options menu UI GameObject
    private bool isPaused = false; // Boolean to check if the game is paused
    private bool isOptionsOpen = false; // Boolean to check if the options menu is open
    public GameObject Spawn;
    public GameObject Player;

    public Timer timer;

    void Update()
    {
        // Check if the player pressed the pause button 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOptionsOpen)
            {
                CloseOptionsMenu();
            }
            else if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu UI
        Time.timeScale = 0f; // Freeze the game
        isPaused = true; // Set the isPaused flag to true
        AudioListener.pause = true; // Pause all audio
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        Time.timeScale = 1f; // Resume the game
        isPaused = false; // Set the isPaused flag to false
        AudioListener.pause = false; // Resume all audio
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
        pauseMenuUI.SetActive(false); // Hide the pause menu UI
    }

    public void RestartBtn()
    {
        Time.timeScale = 1f; // Ensure the game is not paused
        SceneManager.LoadScene(1);
        Resume(); // Ensure pause menu is turned off
        timer.remainingTime = 300;
        Player.transform.position = Spawn.transform.position;
        Physics.SyncTransforms();
    }

    /// <summary>
    /// Method called when the Main Menu button is pressed
    /// </summary>
    public void MainMenu()
    {
        // Loads the scene named "MainMenu" to go back to the main menu
        Time.timeScale = 1f;

        // Unlock and show the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Load the Main Menu scene
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenOptionsMenu()
    {
        optionsMenuUI.SetActive(true); // Show the options menu UI
        isOptionsOpen = true; // Set the isOptionsOpen flag to true
    }

    public void CloseOptionsMenu()
    {
        optionsMenuUI.SetActive(false); // Hide the options menu UI
        isOptionsOpen = false; // Set the isOptionsOpen flag to false
    }
}