using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : Interactable
{
    public GameObject gun; // Reference to the gun GameObject to be enabled on the player

    public void PickupGun(Player player)
    {
        player.EnableGun();
        Destroy(gameObject); // Destroy the pickup object after pickup
    }
}


