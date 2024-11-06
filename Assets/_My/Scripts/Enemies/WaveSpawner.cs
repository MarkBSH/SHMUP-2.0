using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Waves
{
    [SerializeField] public int enemy1;
    [SerializeField] public int enemy2;
    [SerializeField] public int enemy3;
}

[System.Serializable]

public class Rounds
{
    public List<Waves> waves;
}

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] List<Rounds> rounds;

    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    [SerializeField] GameObject boss;

    public int currentWave = 0;
    [SerializeField] float spawnInterval = 10;
    public List<GameObject> spawnedEnemies = new();
    bool spawningWaves = false;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    void Update()
    {
        if (spawnedEnemies.Count == 0 && spawningWaves == false)
        {
            currentWave++;
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        spawningWaves = true;

        for (int i = 0; i < rounds[currentWave].waves.Count; i++)
        {
            for (int j = 0; j < rounds[currentWave].waves[i].enemy1; j++)
            {
                spawnedEnemies.Add(Instantiate(enemy1, new Vector3(0, 8, 0), Quaternion.Euler(0, 0, 0)));
            }
            for (int j = 0; j < rounds[currentWave].waves[i].enemy2; j++)
            {
                spawnedEnemies.Add(Instantiate(enemy2, new Vector3(0, 8, 0), Quaternion.Euler(0, 0, 0)));
            }
            for (int j = 0; j < rounds[currentWave].waves[i].enemy3; j++)
            {
                spawnedEnemies.Add(Instantiate(enemy3, new Vector3(0, 8, 0), Quaternion.Euler(0, 0, 0)));
            }

            yield return new WaitForSeconds(spawnInterval);

            if (i == rounds[currentWave].waves.Count - 1)
            {
                spawnedEnemies.Add(Instantiate(boss, new Vector3(0, 8, 0), Quaternion.Euler(0, 0, 0)));
            }
        }

        spawningWaves = false;
    }
}