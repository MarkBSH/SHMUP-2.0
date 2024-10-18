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
            transform.Translate(Vector3.up * bulletVelocity * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * bulletVelocity * Time.deltaTime);
        }
    }
}
