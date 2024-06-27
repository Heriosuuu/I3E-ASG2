using UnityEngine;

public class Medkit : Interactable
{
    [SerializeField]
    private AudioClip collectAudio;

    public int heal = 20;
    public void UpdatePlayerInteractable(Player player)
    {
        player.UpdateMedkit(this);
    }

    public void RemovePlayerInteractable(Player player)
    {
        player.UpdateMedkit(null);
    }

    public virtual void Collected(Player player)
    {
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
        Destroy(gameObject);
        Debug.Log("Heal");
        player.GetComponent<PlayerHealth>().RestoreHealth(heal);
        
    }
}