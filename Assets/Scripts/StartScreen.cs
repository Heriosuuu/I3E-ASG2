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

    public void StartBtn()
    {
        Debug.Log("Start button clicked");
        SceneManager.LoadScene("SampleScene");
    }
}
