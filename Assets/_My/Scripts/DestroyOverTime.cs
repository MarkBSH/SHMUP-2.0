using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] float destroyTimer = 0;

    protected void DestroyOverTimer()
    {
        Destroy(gameObject, destroyTimer);
    }
}
