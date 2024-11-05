using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    WaveSpawner waveSpawner;
    [SerializeField] int HP;
    [SerializeField] int score = 10;
    [SerializeField] List<GameObject> powerUps = new();
    [SerializeField] GameObject deathParticles;

    void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();
        HP = (4 * waveSpawner.currentWave) + 12;
    }

    void Update()
    {
        if (HP <= 0)
        {
            waveSpawner.spawnedEnemies.Remove(gameObject);

            ScoreManager.Instance.AddScore(score);

            Instantiate(deathParticles, transform.position, Quaternion.identity);

            Instantiate(SpawnPowerUps.Instance.PickBossPowerUp(), transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    public void LoseHP(int loseHP)
    {
        HP -= loseHP;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player Attack"))
        {
            LoseHP(other.gameObject.GetComponent<AttackMovement>().DMG);
            Destroy(other.gameObject);
        }
    }
}
