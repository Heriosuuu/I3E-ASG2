using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EscapePod : Interactable
{
    public GameObject energyPod; // Reference to the energy pod GameObject

    [SerializeField]
    TextMeshProUGUI hintText;

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
    }
}