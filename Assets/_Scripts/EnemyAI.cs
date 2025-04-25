using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 20f;
    public float attackRange = 10f;
    public float moveSpeed = 3f;
    public float attackCooldown = 2f;
    private float lastAttackTime = -999f;


    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        // Automatically finds player if its not assigned
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj) player = playerObj.transform;
        }
    }

    void Update()
    {
        if (isDead || player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", true);
            // I need to put attack logic here (like shooting or cooldown etc.)
            if (Time.time > lastAttackTime + attackCooldown)
            {
                lastAttackTime = Time.time;
    
                // Try damaging Me/The Player
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(10); 
                }
            }
        }
        else if (distance <= detectionRange)
        {
            animator.SetBool("isMoving", true);
            animator.SetBool("isAttacking", false);

            // Move towards  Me/The Player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.LookAt(player);
        }
        else
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", false);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
        Debug.Log("K pressed — taking damage!");
        TakeDamage(100);  // You can use any number here
        }
    }

    public void TakeDamage(int amount)
    {
        // For later. It's health system
        if (!isDead)
        {
            isDead = true;
            animator.SetTrigger("Die");
            // Maybe?: Destroy(gameObject, 3f); // Clean up after death
        }
    }
}
