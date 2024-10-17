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

    public virtual void Update()
    {
        if (HP <= 0)
        {
            //Death
            Instantiate(deathParticals, transform.position, Quaternion.identity);

            if (Random.Range(0, powerUpChance) == 1)
            {
                Instantiate(powerUps[Random.Range(0, powerUps.Count)], transform.position, Quaternion.identity);
            }

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
