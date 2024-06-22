using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickUp : Interactable
{
    public void PickupEnergyPod()
    {
        GameManager.Instance.haveEnergy = true;
        Destroy(gameObject); // Destroy the pickup object after pickup
    }
}
