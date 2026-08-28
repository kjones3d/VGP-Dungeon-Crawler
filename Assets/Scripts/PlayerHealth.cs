using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages player health, damage, and healing
/// Week 2 - Day 1: C# Fundamentals Review
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    // Variables - declare health and maxHealth here
    public int health;
    public int maxHealth;

    private PlayerInput playerInput;
    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    void Start()
    {
        health = 100;
        maxHealth = 100;


        Debug.Log("Player health initialized: " + health);
    }

    /// <summary>
    /// Reduces player health by the damage amount
    /// </summary>
    /// <param name="damage">Amount of damage to take</param>
    public void TakeDamage(int damage)
    {
        // TODO: Subtract damage from health
        health -= damage;

        // TODO: Add validation - health can't go below 0

        if (health < 0)
        {
            health = 0;
        }



        Debug.Log("Player took " + damage + " damage. Health: " + health);

        // TODO: Check if player died (health <= 0)
        if (health <= 0)
        {
            Debug.Log("Player Died!");
        }
    }

    /// <summary>
    /// INDEPENDENT PRACTICE: Restores player health by the heal amount
    /// </summary>
    /// <param name="amount">Amount of health to restore</param>
    public void Heal(int amount)
    {
        // TODO: Add healing amount to health
        health += amount;

        // TODO: Add validation - health can't exceed maxHealth
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        // TODO: Debug.Log to show healing worked
        Debug.Log("Player healed " + amount + " health. Health: " + health);

    }
    
}
