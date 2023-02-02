using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty currentDifficultyType;

    public GameObject[] enemyPrefabs;
    public Transform[] spawnPointsEasy, spawnPointsMedium, spawnPointsHard;
    public List<GameObject> enemyList;
    public GameObject nextWaveButton;
    public GameObject mainTree;
    public GameObject winText;

    public int wave = 0;
    private int maxWaves = 3;
    public int enemyCount;

    public bool canSpawnWave = false;
    public bool isPlayingGame = false;
    private bool gameWon = false;

    public int[] giveCurrency;

    private void Start()
    {
        canSpawnWave = false;

        if (currentDifficultyType == Difficulty.Easy)
        {
            enemyCount = 18;
        }
        if (currentDifficultyType == Difficulty.Medium)
        {
            enemyCount = 27;
        }
        if (currentDifficultyType == Difficulty.Hard)
        {
            enemyCount = 38;
        }
    }

    [ContextMenu("Test Start Easy")]
    public void TestStart() {
        SetDifficulty(0);
        IsGameRunning(true);
        StartNextWave();
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

        if (wave >= maxWaves && gameWon)
        {
            winText.SetActive(true);
        }

        NextWaveEnemyCounts();
    }

    public void SpawnEnemies()
    {
        if(isPlayingGame)
        {
            if (currentDifficultyType == Difficulty.Easy)
            {
                int spawnIndex = Random.Range(0, spawnPointsEasy.Length);
                int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], spawnPointsEasy[spawnIndex].position, Quaternion.identity);
                enemyList.Add(enemy);
            }
            if (currentDifficultyType == Difficulty.Medium)
            {
                int spawnIndex = Random.Range(0, spawnPointsMedium.Length);
                int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], spawnPointsMedium[spawnIndex].position, Quaternion.identity);
                enemyList.Add(enemy);
            }
            if (currentDifficultyType == Difficulty.Hard)
            {
                int spawnIndex = Random.Range(0, spawnPointsHard.Length);
                int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], spawnPointsHard[spawnIndex].position, Quaternion.identity);
                enemyList.Add(enemy);
            }
        }
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
            GetCurrency();
        }
    }

    public void ResetWaves()
    {
        wave = 0;
        canSpawnWave = false;

        foreach (GameObject gameobject in enemyList)
        {
            Destroy(gameobject);
        }
    }

    public void SetDifficulty(int difficultyInt)
    {
        if (difficultyInt == 0)
        {
            currentDifficultyType = Difficulty.Easy;
        }
        else if (difficultyInt == 1)
        {
            currentDifficultyType = Difficulty.Medium;
        }
        else if (difficultyInt == 2)
        {
            currentDifficultyType = Difficulty.Hard;
        }
    }

    public void IsGameRunning(bool isGame)
    {
        if (isGame)
        {
            isPlayingGame = true;
        }
        else
        {
            isPlayingGame = false;
        }
    }


    public void NextWaveEnemyCounts()
    {
        // EASY
        if (currentDifficultyType == Difficulty.Easy && wave == 1 && enemyCount == 15)
        {
            nextWaveButton.SetActive(true);
        }
        else if (currentDifficultyType == Difficulty.Easy && wave == 2 && enemyCount == 9)
        {
            nextWaveButton.SetActive(true);
        }
        else if (currentDifficultyType == Difficulty.Easy && wave == 3 && enemyCount == 0)
        {
            gameWon = true;
        }

        // MEDIUM
        if (currentDifficultyType == Difficulty.Medium && wave == 1 && enemyCount == 21)
        {
            nextWaveButton.SetActive(true);
        }
        else if (currentDifficultyType == Difficulty.Medium && wave == 2 && enemyCount == 12)
        {
            nextWaveButton.SetActive(true);
        }
        else if (currentDifficultyType == Difficulty.Medium && wave == 3 && enemyCount == 0)
        {
            gameWon = true;
        }

        // HARD
        if (currentDifficultyType == Difficulty.Hard && wave == 1 && enemyCount == 29)
        {
            nextWaveButton.SetActive(true);
        }
        else if (currentDifficultyType == Difficulty.Hard && wave == 2 && enemyCount == 17)
        {
            nextWaveButton.SetActive(true);
        }
        else if (currentDifficultyType == Difficulty.Hard && wave == 3 && enemyCount == 0)
        {
            gameWon = true;
        }
    }

    public void GetCurrency()
    {
        if (wave != 1)
        {
            PlayerInventory.instance.UpdateLifeEssenceBalance(giveCurrency[(int)currentDifficultyType]);
        }
    }

    public IEnumerator CanSpawnWave()
    {
        yield return new WaitForSeconds(1f);
        canSpawnWave = false;
    }
}
