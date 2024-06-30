using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerFall : MonoBehaviour
{
    public GameObject target;  // The GameObject to be destroyed
    public GameObject Obj;
    public GameObject Obj2;
    public AudioClip destroySound; // The sound clip to play when the target is destroyed

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(destroySound, transform.position, 1f);
            Obj.SetActive(true); 
            Obj2.SetActive(true);
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
