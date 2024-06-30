/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Manages player spawning in the game. Provides functionality to set the player's position to a default spawn point.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance; // Singleton instance of the SpawnManager
    public Transform defaultSpawnPoint; // Default spawn point if no other specified

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of SpawnManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene changes
        }
        else if (Instance != this && Instance != null)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    /// <summary>
    /// Sets the position and rotation of the player to the default spawn point.
    /// </summary>
    /// <param name="player">The transform of the player object to spawn.</param>
    public void SetPlayerPosition(Transform player)
    {
        Transform spawnPoint = defaultSpawnPoint;
        player.position = spawnPoint.position;
        player.rotation = spawnPoint.rotation;
    }
}
