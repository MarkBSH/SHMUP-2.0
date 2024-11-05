using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    TextMeshProUGUI HPText;
    public int maxHP = 3;
    public int HP;

    void Start()
    {
        HP = maxHP;
        HPText = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
        HPText.text = ": " + HP;
    }

    void DeathCheck()
    {
        if (HP <= 0)
        {
            //death

            ScoreManager.Instance.LoadHighscores();
        }
    }

    public void LoseHP(int loseHP)
    {
        HP -= loseHP;

        HPText.text = ": " + HP;

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
