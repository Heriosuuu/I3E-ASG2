/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Manages the interaction and functionality of the escape pod in the game.
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EscapePod : Interactable
{
    public GameObject energyPod; // Reference to the energy pod GameObject
    public GameObject escapeZone; // Reference to the escape zone GameObject
    public GameObject obj2; // Reference to another GameObject to activate upon interaction

    [SerializeField] TextMeshProUGUI hintText; // Reference to the hint text displayed

    public void Start()
    {
        // Find and store the GameObject with the "Hint" tag
        GameObject hintObject = GameObject.FindGameObjectWithTag("Hint");
    }

    /// <summary>
    /// Enables the hint text and activates obj2 GameObject temporarily.
    /// </summary>
    public void EnableHintText()
    {
        obj2.SetActive(true); // Activate obj2 GameObject
        hintText.gameObject.SetActive(true); // Activate hint text
        StartCoroutine(DisableHintText()); // Start coroutine to disable hint text after delay
    }

    /// <summary>
    /// Coroutine to disable the hint text after a specified delay.
    /// </summary>
    IEnumerator DisableHintText()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        hintText.gameObject.SetActive(false); // Disable hint text
    }

    /// <summary>
    /// Activates the energy pod and escape zone GameObjects.
    /// </summary>
    public void ActivateEnergyPod()
    {
        energyPod.SetActive(true); // Activate energy pod
        escapeZone.SetActive(true); // Activate escape zone
    }
}
