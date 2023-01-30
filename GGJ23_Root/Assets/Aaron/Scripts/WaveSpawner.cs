using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty currentDifficultyType;

    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;

    private int wave = 1;
    private int maxWaves = 3;
    public int enemyCount;

    public bool canSpawnWave = true;

    private void Start()
    {
        switch (currentDifficultyType)
        {
            case Difficulty.Easy:
                enemyCount = 3;
                break;
            case Difficulty.Medium:
                enemyCount = 4;
                break;
            case Difficulty.Hard:
                enemyCount = 5;
                break;
        }
        Invoke("SpawnEnemies", 1f);
        Invoke("SpawnEnemies", 3f);
        Invoke("SpawnEnemies", 5f);
    }

    public void Update()
    {
        if (wave == maxWaves)
        {
            canSpawnWave = false;
        }
    }

    public void SpawnEnemies()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[enemyIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
    }

    public void StartNextWave()
    {
        if (canSpawnWave)
        {
            wave++;
            Invoke("SpawnEnemies", 1f);
            Invoke("SpawnEnemies", 3f);
            Invoke("SpawnEnemies", 5f);
        }
    }
}
