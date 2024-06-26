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
            if (target != null)
            {
                // First, store the position of the target
                Vector3 targetPosition = target.transform.position;

                // Destroy the target GameObject
                Destroy(target);

                // Play the destroy sound at the stored position
                if (destroySound != null)
                {
                    AudioSource.PlayClipAtPoint(destroySound, targetPosition, 1f);
                }
            }
        }
    }
}
