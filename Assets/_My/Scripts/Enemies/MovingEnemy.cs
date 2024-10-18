using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : BaseEnemy
{
    float moveSpeed;
    Vector3 goscreen;
    Vector3 direction;

    public bool goToPlayer;

    public override void Start()
    {
        base.Start();

        if (Random.Range(0, 2) == 0)
        {
            goToPlayer = true;
        }
        else
        {
            goToPlayer = false;
        }

        direction = Vector3.left;
    }

    public override void Update()
    {
        base.Update();

        goscreen = Camera.main.WorldToScreenPoint(transform.position);
        float distX = Vector3.Distance(new Vector3(Screen.width / 2, 0f, 0f), new Vector3(goscreen.x, 0f, 0f));

        if (distX > Screen.width / 2)
        {
            if (goscreen.x > 0)
            {
                direction = Vector3.right;
            }
            else
            {
                direction = Vector3.left;
            }
        }

        moveSpeed = 1 + (waveSpawner.currentWave / 4);

        if (startPosTimer > 1)
        {
            if (goToPlayer)
            {
                transform.Translate(Vector3.down * moveSpeed / 4 * Time.deltaTime);
                transform.Translate(direction * moveSpeed * Time.deltaTime);

                float distY = Vector3.Distance(new Vector3(Screen.height / 2, 0f, 0f), new Vector3(goscreen.y, 0f, 0f));

                if (distY > Screen.height / 2 + 10)
                {
                    transform.position = new Vector3(transform.position.x, -transform.position.y - 0.1f, transform.position.z);
                }
            }
            else
            {
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
        }
    }
}