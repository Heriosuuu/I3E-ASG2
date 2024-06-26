using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class TriggerFall : MonoBehaviour
{
    public GameObject target;  // The GameObject to be destroyed

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (target != null)
            {
                Destroy(target);
            }
        }
    }
}
