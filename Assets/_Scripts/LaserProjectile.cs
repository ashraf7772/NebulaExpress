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
        // 
        rb = GetComponent<Rigidbody>();

        // 
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // 
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        // 
        rb.velocity = transform.forward * laserSpeed;

        // 
        Destroy(gameObject, lifeTime);
    }

    // 
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Laser hit: " + collision.gameObject.name);
        Destroy(gameObject);
    }

    // 
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Laser triggered on: " + other.name);
        Destroy(gameObject);
    }
}
