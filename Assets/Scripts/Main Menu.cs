using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject howToPlayImage;
    public GameObject optionsPanel;

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

    // Quit the game
    public void QuitGame()
    {
        Application.Quit(); // Quit the application (only works in built versions)
    }
}
