using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    GameObject playerObj;
    [SerializeField] float shieldTime;

    void Start()
    {
        playerObj = GameObject.Find("Player");
        Destroy(gameObject, shieldTime);
    }

    void Update()
    {
        transform.position = playerObj.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy Attack"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
