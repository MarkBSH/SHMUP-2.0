using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPowerUp : PowerupBase
{
    PlayerHealth playerHealthScript;

    void Start()
    {
        playerHealthScript = FindObjectOfType<PlayerHealth>();
    }

    protected override void PickUp()
    {
        playerHealthScript.HP++;

        Debug.Log("jkjihg");
        
        base.PickUp();
    }
}