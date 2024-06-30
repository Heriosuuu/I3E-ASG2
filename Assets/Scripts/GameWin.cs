/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Manages game win functionalities such as setting up and displaying the game win screen, handling restart and main menu button actions, and managing scene transitions in Unity.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public Timer timer;
    public GameObject Spawn;
    public GameObject Player;

    /// <summary>
    /// Method to setup and display the Game Win screen
    /// </summary>
    public void Setup()
    {
        // Activates the GameObject this script is attached to, making the win screen visible
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Method called when the Restart button is pressed
    /// </summary>
    public void RestartBtn()
    {
        Debug.Log("Button pressed");
        Time.timeScale = 1f; // Ensure the game is not paused
        SceneManager.LoadScene(1);
        timer.remainingTime = 300;
        Player.transform.position = Spawn.transform.position;
        Physics.SyncTransforms();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Method called when the Main Menu button is pressed
    /// </summary>
    public void MainMenu()
    {
        Debug.Log("Button pressed");
        // Deactivate the win screen
        gameObject.SetActive(false);
        Time.timeScale = 1f;

        // Unlock and show the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Load the Main Menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
