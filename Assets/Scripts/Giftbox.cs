/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Represents an interactive crate that, when interacted with, plays a collection sound, spawns a collectible item, and then destroys itself.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giftbox : Interactable
{
    [SerializeField]
    private AudioClip collectAudio;

    [SerializeField]
    private GameObject collectibleToSpawn;

    /// <summary>
    /// Method to interact with the gift box.
    /// Plays a collection sound, spawns a collectible, and destroys the gift box.
    /// </summary>
    public void Interact()
    {
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
        SpawnCollectible();
        Destroy(gameObject);
    }

    /// <summary>
    /// Spawns the collectible item at the gift box's position.
    /// </summary>
    void SpawnCollectible()
    {
        Instantiate(collectibleToSpawn, transform.position, collectibleToSpawn.transform.rotation);
    }
}
