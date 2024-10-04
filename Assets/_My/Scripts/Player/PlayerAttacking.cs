using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] GameObject bulletObj;
    [SerializeField] GameObject attackPoint;

    float cooldownTimer = 0;
    [SerializeField] float cooldownTarget = 0.5f;

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
            Instantiate(bulletObj, attackPoint.transform.position, attackPoint.transform.rotation);
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
