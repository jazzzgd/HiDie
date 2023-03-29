using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitPickup : MonoBehaviour
{
    public float healAmount; // The amount of health the medkit restores

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with the medkit
        if (other.gameObject.CompareTag("Player"))
        {
            // Get the player's health component
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Restore the player's health by the specified amount
                playerHealth.RestoreHealth(healAmount);
                AudioManager.instance.PlaySFX(5);
                // Destroy the medkit pickup
                Destroy(gameObject);
            }
        }
    }
}
