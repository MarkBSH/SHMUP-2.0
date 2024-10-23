using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] GameObject bulletObj;
    [SerializeField] GameObject attackPoint;

    float cooldownTimer = 0;
    public float cooldownTarget = 0.5f;
    public int projectileCount = 1;
    float shotSpread = 0.4f;

    bool isShooting = false;

    void Update()
    {
        if (cooldownTimer <= cooldownTarget)
        {
            cooldownTimer += Time.deltaTime;
        }

        if (isShooting)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (cooldownTimer >= cooldownTarget)
        {
            for (int i = 0; i < projectileCount; i++)
            {
                Vector3 attackLocation = new(attackPoint.transform.position.x - (shotSpread * (projectileCount - 1) / 2) + (shotSpread * i), attackPoint.transform.position.y, attackPoint.transform.position.z);
                Instantiate(bulletObj, attackLocation, attackPoint.transform.rotation);
            }

            cooldownTimer = 0;
        }
    }

    public void StartShooting(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            isShooting = true;
        }
        if (_context.canceled)
        {
            isShooting = false;
        }
    }
}
