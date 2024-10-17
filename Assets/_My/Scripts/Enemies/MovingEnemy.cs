using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : BaseEnemy
{
    WaveSpawner waveSpawner;

    Vector3 startPos;
    float startPosTimer = 0;
    float startPosSpeed;

    [SerializeField] float moveSpeed;
    Vector3 goscreen;
    Vector3 direction;

    public bool goToPlayer;

    void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();

        if (Random.Range(0, 2) == 0)
        {
            goToPlayer = true;
        }
        else
        {
            goToPlayer = false;
        }

        direction = Vector3.left;

        startPos = new Vector3(Random.Range(-9f, 9f), Random.Range(0f, 4f), 0);
        startPosSpeed = Random.Range(2f, 8f);
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

        if (startPosTimer < 1)
        {
            startPosTimer += Time.deltaTime;
            GoToStart();
        }
        else
        {
            if (goToPlayer)
            {
                transform.Translate(Vector3.down * moveSpeed / 4 * Time.deltaTime);
                transform.Translate(direction * moveSpeed * Time.deltaTime);

                float distY = Vector3.Distance(new Vector3(Screen.height / 2, 0f, 0f), new Vector3(goscreen.y, 0f, 0f));

                if (distY > Screen.height / 2)
                {
                    transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
                }
            }
            else
            {
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }


        }
    }

    void GoToStart()
    {
        transform.position = Vector3.Lerp(transform.position, startPos, startPosTimer / startPosSpeed);
    }
}