using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EscapePod : Interactable
{
    public GameObject energyPod; // Reference to the energy pod GameObject
    public GameObject escapeZone;

    [SerializeField]
    TextMeshProUGUI hintText;

    public void Start()
    {

        GameObject hintObject = GameObject.FindGameObjectWithTag("Hint");
    }
    public void EnableHintText()
    {
        hintText.gameObject.SetActive(true);
        StartCoroutine(DisableHintText());
    }

    IEnumerator DisableHintText()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        hintText.gameObject.SetActive(false);
    }

    public void ActivateEnergyPod()
    {
        energyPod.SetActive(true);
        escapeZone.SetActive(true);
    }
}