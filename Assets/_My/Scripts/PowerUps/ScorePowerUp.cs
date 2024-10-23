using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePowerUp : PowerupBase
{
    ScoreManager scoreManagerScript;

    [SerializeField] int addedScore = 100;

    void Start()
    {
        scoreManagerScript = FindObjectOfType<ScoreManager>();
    }

    protected override void PickUp()
    {
        scoreManagerScript.scoreCounter += addedScore;

        base.PickUp();
    }
}