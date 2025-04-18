using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    public float laserSpeed = 50f;
    public float lifeTime = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;  // Lasers typically don't fall due to gravity
        }

        // Move the laser along its forward axis
        rb.velocity = transform.forward * laserSpeed;

        // Destroy after a short time to prevent clutter
        Destroy(gameObject, lifeTime);
    }
}
