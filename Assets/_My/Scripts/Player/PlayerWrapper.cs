using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWrapper : MonoBehaviour
{
    Vector3 goscreen;

    void Update()
    {
        goscreen = Camera.main.WorldToScreenPoint(transform.position);
        float distX = Vector3.Distance(new Vector3(Screen.width / 2, 0f, 0f), new Vector3(goscreen.x, 0f, 0f));

        if (distX > Screen.width / 2 + 50)
        {
            if (goscreen.x > 0)
            {
                transform.position = new Vector3(-transform.position.x + 0.5f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(-transform.position.x - 0.5f, transform.position.y, transform.position.z);
            }
        }
    }
}