using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    public GameObject medkitPrefab; // The prefab for the medkit pickup
    public float spawnInterval = 10f; // The interval in seconds between spawns
    public float spawnRadius = 10f; // The radius in which the medkit can spawn

    private float timer; // The timer for tracking spawn intervals

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            // Reset the timer
            timer = 0f;

            // Generate a random position within the spawn radius
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;

            // Spawn the medkit prefab at the random position
            Instantiate(medkitPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
