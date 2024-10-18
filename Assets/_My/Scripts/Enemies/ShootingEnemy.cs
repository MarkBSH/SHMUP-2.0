using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : BaseEnemy
{
    [SerializeField] float shootCooldown;
    float shootTimer = 0;
    bool canShoot = true;

    [SerializeField] EnemyWeapon weapon;

    GameObject playerObj;
    public bool goToPlayer;

    public override void Start()
    {
        base.Start();

        playerObj = GameObject.Find("Player");
        if (Random.Range(0, 2) == 0)
        {
            goToPlayer = true;
        }
        else
        {
            goToPlayer = false;
        }
    }

    public override void Update()
    {
        base.Update();

        weapon.projectileCount = 1 + waveSpawner.currentWave / 2;

        AttackTimer();
        if (shootTimer >= shootCooldown && canShoot)
        {
            StartCoroutine(Attack());
        }

        if (goToPlayer == true)
        {
            Vector3 playerPos = playerObj.transform.position;
            playerPos.z = 0;
            transform.up = transform.position-playerPos;
        }
    }

    void AttackTimer()
    {
        if (shootTimer < shootCooldown)
        {
            shootTimer += Time.deltaTime;
        }
    }

    IEnumerator Attack()
    {
        canShoot = false;

        for (int i = 0; i < weapon.projectileCount; i++)
        {
            if (weapon.spreadShot)
            {
                Instantiate(weapon.bulletObj, transform.position, Quaternion.Euler(0, 0, (weapon.spreadArc / weapon.projectileCount * i) - (weapon.spreadArc / 2) + transform.rotation.z));
            }
            else
            {
                Instantiate(weapon.bulletObj, transform.position, transform.rotation);
                yield return new WaitForSeconds(0.1f);
            }
        }

        shootTimer = 0;
        canShoot = true;
    }
}
