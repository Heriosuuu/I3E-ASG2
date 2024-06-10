using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class IncreaseSpeed : Collectible
{
    public float speedIncrease = 2f;
    

    public override void Collected(Player player)
    {
        base.Collected(player);
        Debug.Log("Incrase spd");

        float currentSpeed = player.GetComponent<FirstPersonController>().MoveSpeed;
        
        currentSpeed += speedIncrease;
        
        Debug.Log(currentSpeed);
        player.GetComponent<FirstPersonController>().MoveSpeed = currentSpeed;
    }
}
