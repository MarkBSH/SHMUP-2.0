using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnIn : MonoBehaviour
{
    float startPosTimer = 0;
    [SerializeField] float startPosSpeed = 2;

    void Update()
    {
        if (startPosTimer < 1 * startPosSpeed)
        {
            startPosTimer += Time.deltaTime;

            transform.position = Vector3.Lerp(new Vector3(0, 8, 0), new Vector3(0, 2, 0), startPosTimer / startPosSpeed);
        }
    }
}
