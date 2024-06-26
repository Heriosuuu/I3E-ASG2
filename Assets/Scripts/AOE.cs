using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEEffect : MonoBehaviour
{
    private Animator animator;
    public float destroyAfter = 1.5f;  // Time after which the GameObject will be destroyed

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.Play("Enlarge");
        StartCoroutine(DestroyAfterTime(destroyAfter));
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
