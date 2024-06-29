using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger zone is the player
        if (other.CompareTag("Player"))
        {
            // Call the GameWin method from the GameManager
            GameManager.Instance.GetComponent<PauseManager>().enabled = false;
            GameManager.Instance.GameWin();
        }
    }
}
