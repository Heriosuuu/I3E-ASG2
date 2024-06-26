using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewZone : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level 1"); // Load the specified scene
        }
    }
}
