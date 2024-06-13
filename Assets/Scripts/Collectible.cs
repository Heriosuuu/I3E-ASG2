using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    private AudioClip collectAudio;

    public int ammo = 15;
    public void UpdatePlayerInteractable(Player player)
    {
        player.UpdateCollectible(this);
    }

    public void RemovePlayerInteractable(Player player)
    {
        player.UpdateCollectible(null);
    }

    public virtual void Collected(Player player)
    {
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
        Debug.Log("collected");
        GameManager.Instance.AddPoint(ammo);
        Destroy(gameObject);
        
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}