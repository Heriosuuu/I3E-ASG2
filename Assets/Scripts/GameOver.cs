/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Manages game over functionalities such as setting up and displaying the game over screen, handling restart and main menu button actions, and managing scene transitions in Unity.
 */

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Timer timer;
    public GameObject Spawn;
    public GameObject Player;

    /// <summary>
    /// Method to setup and display the Game Over screen
    /// </summary>
    public void Setup()
    {
        // Activates the GameObject this script is attached to, making the game over screen visible
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Method called when the Restart button is pressed
    /// </summary>
    public void RestartBtn()
    {
        gameObject.SetActive(false);
        Debug.Log("Button pressed");
        Time.timeScale = 1f; // Ensure the game is not paused
        SceneManager.LoadScene(1);
        timer.remainingTime = 300;
        Player.transform.position = Spawn.transform.position;
        Physics.SyncTransforms();
    }

    /// <summary>
    /// Method called when the Main Menu button is pressed
    /// </summary>
    public void MainMenu()
    {
        gameObject.SetActive(false);
        Debug.Log("Button pressed");
        // Loads the scene named "MainMenu" to go back to the main menu
        Time.timeScale = 1f;

        // Unlock and show the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Load the Main Menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
