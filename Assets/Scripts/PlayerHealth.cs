using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Range(0, 200)] public int startHealth = 100, currentHealth;

    public static bool isDead;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = startHealth; // Set the current health to be the start health, when the game starts.
        healthBar.SetMaxHealth(startHealth);
    }

    private void Update()
    {
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("The player has died!");
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);
    }
}
