using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty currentDifficultyType;

    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public List<GameObject> enemyList;
    public GameObject nextWaveButton;

    public int wave = 0;
    private int maxWaves = 3;
    public int enemyCount;

    public bool canSpawnWave = false;

    private void Start()
    {
        canSpawnWave = false;
    }

    public void Update()
    {
        if (wave >= maxWaves)
        {
            canSpawnWave = false;
        }

        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == null)
            {
                enemyList.RemoveAt(i);
                i--;
                enemyCount--;
            }
        }

        if (!canSpawnWave && enemyCount == 0)
        {
            nextWaveButton.SetActive(true);
        }
    }

    public void SpawnEnemies()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
        enemyList.Add(enemy);
        enemyCount++;
    }

    public void StartNextWave()
    {
        canSpawnWave = true;
        nextWaveButton.SetActive(false);
        wave++;

        if (canSpawnWave)
        {
            ////////// EASY //////////
            if (currentDifficultyType == Difficulty.Easy)
            {
                if (wave == 1)
                {
                    Invoke("SpawnEnemies", 0f);
                    Invoke("SpawnEnemies", 3f);
                    Invoke("SpawnEnemies", 5f);
                }
                else if (wave == 2)
                {
                    Invoke("SpawnEnemies", 0f);
                    Invoke("SpawnEnemies", 3f);
                    Invoke("SpawnEnemies", 5f);
                    Invoke("SpawnEnemies", 7f);
                    Invoke("SpawnEnemies", 9f);
                    Invoke("SpawnEnemies", 9f);
                }
                else if (wave == 3)
                {
                    Invoke("SpawnEnemies", 0f);
                    Invoke("SpawnEnemies", 3f);
                    Invoke("SpawnEnemies", 5f);
                    Invoke("SpawnEnemies", 7f);
                    Invoke("SpawnEnemies", 9f);
                    Invoke("SpawnEnemies", 9f);
                    Invoke("SpawnEnemies", 11f);
                    Invoke("SpawnEnemies", 13f);
                    Invoke("SpawnEnemies", 13f);
                }
            }
            ////////// EASY //////////
            ///////////// MEDIUM //////////
            if (currentDifficultyType == Difficulty.Medium)
            {
                if (wave == 1)
                {
                    Invoke("SpawnEnemies", 0f);
                    Invoke("SpawnEnemies", 3f);
                    Invoke("SpawnEnemies", 5f);
                    Invoke("SpawnEnemies", 7f);
                    Invoke("SpawnEnemies", 9f);
                    Invoke("SpawnEnemies", 11f);
                }
                else if (wave == 2)
                {
                    Invoke("SpawnEnemies", 0f);
                    Invoke("SpawnEnemies", 3f);
                    Invoke("SpawnEnemies", 5f);
                    Invoke("SpawnEnemies", 7f);
                    Invoke("SpawnEnemies", 9f);
                    Invoke("SpawnEnemies", 11f);
                    Invoke("SpawnEnemies", 13f);
                    Invoke("SpawnEnemies", 15f);
                    Invoke("SpawnEnemies", 15f);
                }
                else if (wave == 3)
                {
                    Invoke("SpawnEnemies", 0f);
                    Invoke("SpawnEnemies", 3f);
                    Invoke("SpawnEnemies", 5f);
                    Invoke("SpawnEnemies", 7f);
                    Invoke("SpawnEnemies", 9f);
                    Invoke("SpawnEnemies", 9f);
                    Invoke("SpawnEnemies", 11f);
                    Invoke("SpawnEnemies", 13f);
                    Invoke("SpawnEnemies", 13f);
                    Invoke("SpawnEnemies", 15f);
                    Invoke("SpawnEnemies", 17f);
                    Invoke("SpawnEnemies", 17f);
                }
            }
            ////////// MEDIUM //////////
            ///////////// HARD //////////
            if (currentDifficultyType == Difficulty.Hard)
            {
                if (wave == 1)
                {
                    Invoke("SpawnEnemies", 0f);
                    Invoke("SpawnEnemies", 3f);
                    Invoke("SpawnEnemies", 5f);
                    Invoke("SpawnEnemies", 7f);
                    Invoke("SpawnEnemies", 9f);
                    Invoke("SpawnEnemies", 11f);
                    Invoke("SpawnEnemies", 13f);
                    Invoke("SpawnEnemies", 15f);
                    Invoke("SpawnEnemies", 17f);
                }
                else if (wave == 2)
                {
                    Invoke("SpawnEnemies", 0f);
                    Invoke("SpawnEnemies", 3f);
                    Invoke("SpawnEnemies", 5f);
                    Invoke("SpawnEnemies", 7f);
                    Invoke("SpawnEnemies", 9f);
                    Invoke("SpawnEnemies", 11f);
                    Invoke("SpawnEnemies", 13f);
                    Invoke("SpawnEnemies", 15f);
                    Invoke("SpawnEnemies", 15f);
                    Invoke("SpawnEnemies", 17f);
                    Invoke("SpawnEnemies", 19f);
                    Invoke("SpawnEnemies", 19f);
                }
                else if (wave == 3)
                {
                    Invoke("SpawnEnemies", 0f);
                    Invoke("SpawnEnemies", 3f);
                    Invoke("SpawnEnemies", 5f);
                    Invoke("SpawnEnemies", 7f);
                    Invoke("SpawnEnemies", 9f);
                    Invoke("SpawnEnemies", 9f);
                    Invoke("SpawnEnemies", 11f);
                    Invoke("SpawnEnemies", 13f);
                    Invoke("SpawnEnemies", 13f);
                    Invoke("SpawnEnemies", 15f);
                    Invoke("SpawnEnemies", 17f);
                    Invoke("SpawnEnemies", 17f);
                    Invoke("SpawnEnemies", 19f);
                    Invoke("SpawnEnemies", 21f);
                    Invoke("SpawnEnemies", 23f);
                    Invoke("SpawnEnemies", 23f);
                    Invoke("SpawnEnemies", 25f);

                }
            }
            ////////// HARD //////////

            StartCoroutine(CanSpawnWave());
        }
    }

    public void ResetWaves()
    {
        wave = 0;
        canSpawnWave = false;

        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] != null)
            {
                enemyList.RemoveAll(i => i == null);
                enemyCount = 0;
            }
        }
    }

    public IEnumerator CanSpawnWave()
    {
        yield return new WaitForSeconds(1f);
        canSpawnWave = false;
    }
}
