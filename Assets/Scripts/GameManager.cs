using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int ammo = 15;

    public TextMeshProUGUI scoreText;

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

    public void AddPoint(int ammoCount)
    {
        ammo += ammoCount;
        Debug.Log("Ammo: " + ammo + "/15");
        scoreText.text = "Ammo: " + ammo.ToString() + "/15";
    }
}
