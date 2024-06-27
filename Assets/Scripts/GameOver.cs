using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
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
        // Deactivate the game over screen
        gameObject.SetActive(false);
        // Loads the scene named "Level 1" to restart the game
        SceneManager.LoadScene("Level 1");
    }

    /// <summary>
    /// Method called when the Main Menu button is pressed
    /// </summary>
    public void MainMenu()
    {
        // Deactivate the game over screen
        gameObject.SetActive(false);
        // Loads the scene named "MainMenu" to go back to the main menu
        SceneManager.LoadScene("MainMenu");
    }
}
