using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public bool weaponUpgraded = false;
    PlayerAttacking playerAttacking;
    public bool shipUpgraded = false;
    PlayerMovement playerMovement;
    PlayerHealth playerHealth;

    [SerializeField] Sprite shipUpgrade1;
    [SerializeField] Sprite shipUpgrade2;

    void Start()
    {
        playerAttacking = GetComponent<PlayerAttacking>();
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void WeaponUpgraded()
    {
        weaponUpgraded = true;

        playerAttacking.cooldown = 0.4f;
        playerAttacking.projectileCount = 2;

        gameObject.GetComponent<SpriteRenderer>().sprite = shipUpgrade1;
    }

    public void ShipUpgraded()
    {
        shipUpgraded = true;

        playerMovement.movementSpeed = 8;

        playerHealth.maxHP++;
        playerHealth.HP++;

        gameObject.GetComponent<SpriteRenderer>().sprite = shipUpgrade2;
    }
}
