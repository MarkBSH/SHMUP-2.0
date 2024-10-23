using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBase : MonoBehaviour
{
    [SerializeField] float fallSpeed = 1;

    protected virtual void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    protected virtual void PickUp()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUp();
        }
    }
}