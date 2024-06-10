using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giftbox : MonoBehaviour
{
    [SerializeField]
    private AudioClip collectAudio;

    [SerializeField]
    private GameObject collectibleToSpawn;

    public void Interact()
    {
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
        SpawnCollectible();
        Destroy(gameObject);
    }

    void SpawnCollectible()
    {
        Instantiate(collectibleToSpawn, transform.position, collectibleToSpawn.transform.rotation);
    }
}
