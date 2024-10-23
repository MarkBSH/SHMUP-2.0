using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : PowerupBase
{
    PlayerMain playerMainScript;

    void Start()
    {
        playerMainScript = FindObjectOfType<PlayerMain>();
    }

    protected override void PickUp()
    {
        playerMainScript.WeaponUpgraded();

        base.PickUp();
    }
}