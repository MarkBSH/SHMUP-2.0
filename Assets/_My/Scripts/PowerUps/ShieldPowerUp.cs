using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerupBase
{
    [SerializeField] GameObject shieldObject;

    protected override void PickUp()
    {
        // spawn shield powerup

        base.PickUp();
    }
}