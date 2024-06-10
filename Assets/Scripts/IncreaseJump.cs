using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseJump : Collectible
{
    public float jumpIncrease = 3f;

    public override void Collected(Player player)
    {
        base.Collected(player);
        Debug.Log("Incrase Jump");

        float currentJump = player.GetComponent<FirstPersonController>().JumpHeight;
        currentJump += jumpIncrease;
        Debug.Log(currentJump);
        player.GetComponent<FirstPersonController>().MoveSpeed = currentJump;
    }
    
}
