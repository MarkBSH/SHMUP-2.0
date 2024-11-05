using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPowerUp : PowerupBase
{
    PlayerMain playerMainScript;

    void Start()
    {
        playerMainScript = FindObjectOfType<PlayerMain>();
    }

    protected override void PickUp()
    {
        playerMainScript.ShipUpgraded();

        base.PickUp();
    }
}
