using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLaserShooter : MonoBehaviour
{
    [Header("Laser Settings")]
    public GameObject laserPrefab;             // Prefab to instantiate when firing
    public Transform laserSpawnPoint;          // Where the laser appears on the ship

    [Header("Audio Settings")]
    public AudioSource shootSound;             // Audio source for firing sound

    void Update()
    {
        // Detect input: Spacebar or left mouse button
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Instantiate laser at the spawn point's position and rotation
            if (laserPrefab != null && laserSpawnPoint != null)
            {
                Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);
            }

            // Play shooting sound if assigned
            if (shootSound != null)
            {
                shootSound.Play();
            }
        }
    }
}
