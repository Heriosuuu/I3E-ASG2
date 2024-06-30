/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Controls the functionality of the main menu, including starting the game, showing instructions, managing options, displaying credits, and quitting the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject howToPlayImage; // Reference to the How To Play image GameObject
    public GameObject optionsPanel; // Reference to the options panel GameObject
    public GameObject credits; // Reference to the credits GameObject

    // Start the game and load level 1
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    // Show instructions on how to play
    public void HowToPlay()
    {
        howToPlayImage.SetActive(true); // Activate the How To Play image GameObject
    }

    // Hide instructions on how to play (back button functionality)
    public void HideHowToPlay()
    {
        howToPlayImage.SetActive(false); // Deactivate the How To Play image GameObject
    }

    // Open options panel
    public void OpenOptions()
    {
        optionsPanel.SetActive(true); // Activate the options panel GameObject
    }

    // Close options panel
    public void CloseOptions()
    {
        optionsPanel.SetActive(false); // Deactivate the options panel GameObject
    }

    // Show credits
    public void Credits()
    {
        credits.SetActive(true); // Activate the credits GameObject
    }

    // Close credits
    public void CloseCredits()
    {
        credits.SetActive(false); // Deactivate the credits GameObject
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit(); // Quit the application (only works in built versions)
    }
}
