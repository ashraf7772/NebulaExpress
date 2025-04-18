using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLaserShooter : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform laserSpawnPoint; // Point where lasers spawn, e.g. a child transform at the ship's nose

    void Update()
    {
        // Spacebar or left mouse to shoot
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Create a new laser at the spawn point, matching rotation
            Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);
        }
    }
}