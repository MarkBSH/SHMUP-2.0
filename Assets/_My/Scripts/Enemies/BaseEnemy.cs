using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    protected WaveSpawner waveSpawner;
    [SerializeField] int HP = 1;
    [SerializeField] int score = 10;
    [SerializeField] int powerUpChance = 10;
    [SerializeField] List<GameObject> powerUps = new();
    [SerializeField] GameObject deathParticals;

    Vector3 startPos;
    protected float startPosTimer = 0;
    float startPosSpeed;

    public virtual void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();

        startPos = new Vector3(Random.Range(-9f, 9f), Random.Range(0f, 4f), 0);
        startPosSpeed = Random.Range(2f, 8f);
    }

    public virtual void Update()
    {
        if (startPosTimer < 1)
        {
            startPosTimer += Time.deltaTime;
            GoToStart();
        }

        if (HP <= 0)
        {
            waveSpawner.spawnedEnemies.Remove(gameObject);

            ScoreManager.Instance.AddScore(score);

            Instantiate(deathParticals, transform.position, Quaternion.identity);

            if (Random.Range(0, powerUpChance) == 1)
            {
                //Instantiate(powerUps[Random.Range(0, powerUps.Count)], transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    public void LoseHP(int loseHP)
    {
        HP -= loseHP;
    }

    void GoToStart()
    {
        transform.position = Vector3.Lerp(transform.position, startPos, startPosTimer / startPosSpeed);
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
