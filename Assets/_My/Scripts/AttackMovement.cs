using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackMovement : DestroyOverTime
{
    [SerializeField] bool isPlayer;
    [SerializeField] float bulletVelocity;

    public int DMG;

    void Awake()
    {
        DestroyOverTimer();
    }

    void Update()
    {
        if (isPlayer)
        {
            transform.Translate(0, bulletVelocity * Time.deltaTime, 0);
        }
        else
        {
            transform.Translate(0, -bulletVelocity * Time.deltaTime, 0);
        }
    }
}
