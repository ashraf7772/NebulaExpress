using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class LaserProjectile : MonoBehaviour
{
    [Header("Laser Settings")]
    public float laserSpeed = 50f;
    public float lifeTime = 2f;

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component (ensured by RequireComponent)
        rb = GetComponent<Rigidbody>();

        // Ensure gravity is off so the laser flies straight
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // Better for fast-moving objects
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        // Launch the laser forward
        rb.velocity = transform.forward * laserSpeed;

        // Auto-destroy after a short delay
        Destroy(gameObject, lifeTime);
    }

    // Optional: detect hits if Collider is not a trigger
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Laser hit: " + collision.gameObject.name);
        Destroy(gameObject);
    }

    // Optional: detect hits if Collider is a trigger
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Laser triggered on: " + other.name);
        Destroy(gameObject);
    }
}
