/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Handles the start screen functionality, including starting the game when the start button is clicked.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start script is running");
    }

    /// <summary>
    /// Called when the start button is clicked. Loads the main game scene.
    /// </summary>
    public void StartBtn()
    {
        Debug.Log("Start button clicked");
        SceneManager.LoadScene("SampleScene");
    }
}
