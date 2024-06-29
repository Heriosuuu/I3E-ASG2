using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFall : MonoBehaviour
{
    public GameObject target;  // The GameObject to be destroyed
    public AudioClip destroySound; // The sound clip to play when the target is destroyed

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(destroySound, transform.position, 1f);
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
