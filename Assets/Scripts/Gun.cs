using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;
    public AudioClip fireSound; // Sound clip for firing the gun
    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFireTime && GameManager.Instance.ammo > 0)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Instantiate a bullet at the bulletSpawn position and rotation
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        GameManager.Instance.AddPoint(-1); // Decrease ammo count

        // Play fire sound
        AudioSource.PlayClipAtPoint(fireSound, transform.position, 1f);
    }
}
