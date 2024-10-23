using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 4;
    Vector2 horizontalMovement;

    void Update()
    {
        transform.Translate(horizontalMovement.x * movementSpeed * Time.deltaTime, 0, 0);
    }

    public void MoveHorizontal(InputAction.CallbackContext _context)
    {
        horizontalMovement = _context.ReadValue<Vector2>();
    }
}