using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : BaseEnemy
{
    [SerializeField] float shootCooldown;
    float shootTimer = 0;

    EnemyWeapon weapon;

    void Awake()
    {
        weapon = gameObject.GetComponent<EnemyWeapon>();
    }

    public override void Update()
    {
        base.Update();
        AttackTimer();
        if (shootTimer >= shootCooldown)
        {
            Attack();
        }
    }

    void AttackTimer()
    {
        if (shootTimer < shootCooldown)
        {
            shootTimer += Time.deltaTime;
        }
    }

    void Attack()
    {

    }
}
