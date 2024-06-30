using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewZone : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load
    public GameObject obj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            obj.SetActive(false);
            SceneManager.LoadScene("Level 2");
            GameManager.Instance.GetComponent<Timer>().enabled = false;
        }
    }
}
