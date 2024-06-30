/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Triggers the destruction of a specified GameObject when the player enters a trigger zone.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerFall : MonoBehaviour
{
    public GameObject target;  // The GameObject to be destroyed
    public GameObject Obj;     // Additional GameObject to activate
    public GameObject Obj2;    // Another GameObject to activate
    public AudioClip destroySound; // The sound clip to play when the target is destroyed

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Play destruction sound at the trigger's position
            AudioSource.PlayClipAtPoint(destroySound, transform.position, 1f);

            // Activate additional objects
            Obj.SetActive(true);
            Obj2.SetActive(true);

            // Check if target exists before destroying it
            if (target != null)
            {
                // First, store the position of the target
                Vector3 targetPosition = target.transform.position;

                // Destroy the target GameObject after the sound has been triggered
                Destroy(target);
            }
        }
    }
}
