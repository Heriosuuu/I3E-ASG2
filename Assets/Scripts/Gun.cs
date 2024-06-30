/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Represents a gun that fires bullets when the Fire1 button is pressed, deducting ammo from the GameManager.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab of the bullet to be fired
    public Transform bulletSpawn; // Transform where the bullet will be spawned
    public float fireRate = 0.5f; // Rate of fire in seconds
    public AudioClip fireSound; // Sound clip for firing the gun

    private float nextFireTime = 0f; // Time when the gun can fire again

    void Update()
    {
        // Check if Fire1 button is pressed, enough time has passed since last shot, and ammo is available
        if (Input.GetButton("Fire1") && Time.time > nextFireTime && GameManager.Instance.ammo > 0)
        {
            Shoot(); // Fire the gun
            nextFireTime = Time.time + fireRate; // Set the next allowed fire time
        }
    }

    /// <summary>
    /// Instantiates a bullet prefab at the bullet spawn position and deducts ammo from GameManager.
    /// </summary>
    void Shoot()
    {
        // Instantiate a bullet at the bulletSpawn position and rotation
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Deduct ammo count from GameManager
        GameManager.Instance.AddPoint(-1);

        // Play fire sound
        AudioSource.PlayClipAtPoint(fireSound, transform.position, 1f);
    }
}
