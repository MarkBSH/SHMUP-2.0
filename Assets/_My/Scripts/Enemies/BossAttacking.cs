using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacking : MonoBehaviour
{
    [SerializeField] List<GameObject> attackPoints;
    [SerializeField] EnemyWeapon weapon;

    GameObject playerObj;
    Vector3 playerPos;

    [SerializeField] float shootCooldown;
    float shootTimer = 0;
    bool canShoot = true;

    void Start()
    {
        playerObj = GameObject.Find("Player");
    }

    void Update()
    {
        playerPos = playerObj.transform.position;
        playerPos.z = 0;

        AttackTimer();
        if (shootTimer >= shootCooldown && canShoot)
        {
            StartCoroutine(Attack());
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
            for (int j = 0; j < attackPoints.Count; j++)
            {
                attackPoints[j].transform.up = attackPoints[j].transform.position - playerPos;

                Instantiate(weapon.bulletObj, attackPoints[j].transform.position, attackPoints[j].transform.rotation);
                yield return new WaitForSeconds(0.05f);
            }
        }

        shootTimer = Random.Range(0f, 0.3f);
        canShoot = true;
    }
}
