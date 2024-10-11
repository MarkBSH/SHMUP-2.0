using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] int HP = 1;
    [SerializeField] int powerUpChance = 10;
    [SerializeField] List<GameObject> powerUps = new();
    [SerializeField] GameObject deathParticals;


    void Update()
    {
        if (HP <= 0)
        {
            //Death
            if (Random.Range(0, powerUpChance) == 1)
            {
                Instantiate(powerUps[Random.Range(0, powerUps.Count)], transform.position, Quaternion.identity);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player Attack"))
        {
            HP -= 1;
        }
    }
}
