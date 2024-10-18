using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int HP = 3;

    void DeathCheck()
    {
        if (HP <= 0)
        {
            //death

            ScoreManager.Instance.LoadHighscores();

            Debug.Log("death / died");
        }
    }

    public void LoseHP(int loseHP)
    {
        HP -= loseHP;

        DeathCheck();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy Attack"))
        {
            Destroy(other.gameObject);
            LoseHP(other.gameObject.GetComponent<AttackMovement>().DMG);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            LoseHP(other.gameObject.GetComponent<AttackMovement>().DMG);
        }
    }
}
