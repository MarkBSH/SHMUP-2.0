using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int HP = 3;

    void DeathCheck()
    {
        if (HP <= 0)
        {
            //death
        }
    }

    public void HurtPlayer(int loseHP)
    {
        HP =- loseHP;

        DeathCheck();
    }
}
