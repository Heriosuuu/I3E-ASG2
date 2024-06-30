/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Handles transition to Level 2 when the player enters a trigger zone, including fade-in and fade-out animations.
 */

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewZone : MonoBehaviour
{
    public GameObject obj; // Reference to the GameObject to deactivate during transition
    public GameObject Light; // Reference to the light GameObject to activate during transition

    [SerializeField]
    private Animator fadeTransition; // Animator for fade-in and fade-out transitions

    /// <summary>
    /// Coroutine for handling the fade transition and scene loading.
    /// </summary>
    private IEnumerator FadeAndLoadScene()
    {
        // Trigger the fade-out animation
        fadeTransition.SetTrigger("End");

        // Wait for the duration of the fade-out animation
        yield return new WaitForSeconds(0.5f);

        // Deactivate the specified object
        obj.SetActive(false);

        // Trigger the fade-in animation
        fadeTransition.SetTrigger("Start");

        // Load Level 2 scene
        SceneManager.LoadScene("Level 2");

        // Disable the Timer component in GameManager
        GameManager.Instance.GetComponent<Timer>().enabled = false;
    }

    /// <summary>
    /// Method called when another collider enters the trigger collider.
    /// </summary>
    /// <param name="other">The collider entering the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Activate the light
            Light.SetActive(true);

            // Start the fade and load scene coroutine
            StartCoroutine(FadeAndLoadScene());
        }
    }
}
