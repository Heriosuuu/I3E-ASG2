/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Handles a countdown timer and triggers game over when time runs out.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    public float remainingTime;

    /// <summary>
    /// Updates the countdown timer every frame and triggers game over when time runs out.
    /// </summary>
    void Update()
    {
        // Decrease the remaining time by the time elapsed since the last frame
        remainingTime -= Time.deltaTime;

        // Ensure remainingTime doesn't go below zero
        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            TriggerGameOver();
        }

        // Calculate the minutes and seconds from the remaining time
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    /// <summary>
    /// Disables the PauseManager component, logs "Game Over!", and notifies the GameManager about the game over event.
    /// </summary>
    void TriggerGameOver()
    {
        GameManager.Instance.GetComponent<PauseManager>().enabled = false;
        Debug.Log("Game Over!");
        GameManager.Instance.GameOver();
    }
}
