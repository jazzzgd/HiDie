using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerNew : MonoBehaviour {

    public GameObject[] enemies;
    public int numEnemies;
    public float spawnRate;
    public float waveDelay;
    public int waveCount;

    private int currentWave;
    private bool spawningWave;

    void Start () {
        currentWave = 0;
        spawningWave = false;
    }

    void Update () {
        if (!spawningWave && currentWave < waveCount) {
            spawningWave = true;
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave () {
        currentWave++;
        for (int i = 0; i < numEnemies; i++) {
            int enemyIndex = Random.Range(0, enemies.Length);
            Instantiate(enemies[enemyIndex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
        spawningWave = false;
        yield return new WaitForSeconds(waveDelay);
    }
}

