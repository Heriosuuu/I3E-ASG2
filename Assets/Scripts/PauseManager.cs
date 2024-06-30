/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Manages game pausing, resuming, and options menu functionality. Allows players to pause the game,
 * resume gameplay, restart the level, return to the main menu, and toggle the options menu.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu UI GameObject
    public GameObject optionsMenuUI; // Reference to the options menu UI GameObject
    public GameObject Spawn; // Reference to the spawn point GameObject
    public GameObject Player; // Reference to the player GameObject
    public Timer timer; // Reference to the Timer component

    private bool isPaused = false; // Boolean to check if the game is paused
    private bool isOptionsOpen = false; // Boolean to check if the options menu is open

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

    /// <summary>
    /// Pauses the game, showing the pause menu UI and freezing time.
    /// </summary>
    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu UI
        Time.timeScale = 0f; // Freeze the game
        isPaused = true; // Set the isPaused flag to true
        AudioListener.pause = true; // Pause all audio
        Cursor.visible = true; // Show the cursor
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
    }

    /// <summary>
    /// Resumes the game, hiding the pause menu UI and unfreezing time.
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1f; // Resume the game
        isPaused = false; // Set the isPaused flag to false
        AudioListener.pause = false; // Resume all audio
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
        pauseMenuUI.SetActive(false); // Hide the pause menu UI
    }

    /// <summary>
    /// Restarts the current level, resetting the timer and player position.
    /// </summary>
    public void RestartBtn()
    {
        Time.timeScale = 1f; // Ensure the game is not paused
        SceneManager.LoadScene(1); // Reload the current scene
        Resume(); // Ensure pause menu is turned off
        timer.remainingTime = 300; // Reset the timer
        Player.transform.position = Spawn.transform.position; // Reset player position
        Physics.SyncTransforms(); // Synchronize physics transforms
    }

    /// <summary>
    /// Loads the Main Menu scene, unlocking the cursor and showing it.
    /// </summary>
    public void MainMenu()
    {
        Time.timeScale = 1f; // Resume time in case paused
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
        SceneManager.LoadScene("MainMenu"); // Load the Main Menu scene
    }

    /// <summary>
    /// Opens the options menu, showing the options menu UI.
    /// </summary>
    public void OpenOptionsMenu()
    {
        optionsMenuUI.SetActive(true); // Show the options menu UI
        isOptionsOpen = true; // Set the isOptionsOpen flag to true
    }

    /// <summary>
    /// Closes the options menu, hiding the options menu UI.
    /// </summary>
    public void CloseOptionsMenu()
    {
        optionsMenuUI.SetActive(false); // Hide the options menu UI
        isOptionsOpen = false; // Set the isOptionsOpen flag to false
    }
}
