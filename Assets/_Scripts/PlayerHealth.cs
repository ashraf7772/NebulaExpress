using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start() => currentHealth = maxHealth;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took damage. Health: " + currentHealth);
        
        if (currentHealth <= 0)
        {
            Debug.Log("Player died!");
            // Trigger GAME OVER screen here
        }
    }
}
