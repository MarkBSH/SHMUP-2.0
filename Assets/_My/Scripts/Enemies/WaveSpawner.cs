using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] List<Wave> waves = new();
    int currentWave = 0;
    [SerializeField] float spawnInterval = 10;
    List<GameObject> spawnedEnemies = new();
    bool spawningWaves = false;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    void Update()
    {
        if (spawnedEnemies.Count == 0 && spawningWaves == false)
        {
            currentWave ++;
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        spawningWaves = true;

        for (int i = 0; i < waves[currentWave].enemyGroups.Count; i++)
        {
            for (int j = 0; j < waves[currentWave].enemyGroups[i].Enemies.Count; j++)
            {
                spawnedEnemies.Add(Instantiate(waves[currentWave].enemyGroups[i].Enemies[j], new Vector3(Random.Range(-7, 7), 6, 0), Quaternion.Euler(0, 180, 0)));
            }

            yield return new WaitForSeconds(spawnInterval);
        }

        spawningWaves = false;
    }
}
