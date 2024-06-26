using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    public Transform defaultSpawnPoint; // Default spawn point if no other specified

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerPosition(Transform player)
    {
        Transform spawnPoint = defaultSpawnPoint;
        player.position = spawnPoint.position;
        player.rotation = spawnPoint.rotation;
    }
}
