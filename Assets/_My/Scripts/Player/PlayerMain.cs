using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public bool weaponUpgraded = false;
    PlayerAttacking playerAttacking;
    public bool shipUpgraded = false;
    PlayerMovement playerMovement;

    [SerializeField] Sprite shipUpgrade1;
    [SerializeField] Sprite shipUpgrade2;

    void Start()
    {
        playerAttacking = GetComponent<PlayerAttacking>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void WeaponUpgraded()
    {
        weaponUpgraded = true;

        playerAttacking.cooldownTarget = 0.3f;
        playerAttacking.projectileCount = 2;

        gameObject.GetComponent<SpriteRenderer>().sprite = shipUpgrade1;
    }

    public void ShipUpgraded()
    {
        shipUpgraded = true;

        playerMovement.movementSpeed = 8;

        gameObject.GetComponent<SpriteRenderer>().sprite = shipUpgrade2;
    }
}
