using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 20f;
    public float rotationSpeed = 50f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Forward and backward movement
        float moveInput = Input.GetAxis("Vertical") * speed;
        
        // Rotation (Yaw left/right)
        float rotationInput = Input.GetAxis("Horizontal") * rotationSpeed;
        
        // Apply movement
        rb.velocity = transform.forward * moveInput;
        
        // Apply rotation
        rb.angularVelocity = new Vector3(0, rotationInput * Mathf.Deg2Rad, 0);
    }
}
