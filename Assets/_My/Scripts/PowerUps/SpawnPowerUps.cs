using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    private static SpawnPowerUps m_Instance;
    public static SpawnPowerUps Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<SpawnPowerUps>();
                if (m_Instance == null)
                {
                    GameObject _obj = new()
                    {
                        name = typeof(SpawnPowerUps).Name
                    };
                    m_Instance = _obj.AddComponent<SpawnPowerUps>();
                }
            }
            return m_Instance;
        }
    }

    PlayerMain playerMainScript;
    PlayerHealth playerHealthScript;
    [SerializeField] List<GameObject> powerUps = new();

    void Start()
    {
        playerMainScript = FindObjectOfType<PlayerMain>();
        playerHealthScript = FindObjectOfType<PlayerHealth>();
    }

    public GameObject PickPowerUp()
    {
        if (playerHealthScript.HP < playerHealthScript.maxHP)
        {
            int randomPowerUp1 = Random.Range(0, 3);
            if (randomPowerUp1 == 0)
            {
                return powerUps[2];
            }
            else if (randomPowerUp1 == 1)
            {
                return powerUps[3];
            }
            else
            {
                return powerUps[4];
            }
        }
        else
        {
            int randomPowerUp2 = Random.Range(0, 2);
            if (randomPowerUp2 == 0)
            {
                return powerUps[3];
            }
            else
            {
                return powerUps[4];
            }
        }
    }

    public GameObject PickBossPowerUp()
    {
        if (playerMainScript.weaponUpgraded == false)
        {
            return powerUps[0];
        }
        else if (playerMainScript.shipUpgraded == false)
        {
            return powerUps[1];
        }
        else if (playerHealthScript.HP < playerHealthScript.maxHP)
        {
            int randomPowerUp1 = Random.Range(0, 3);
            if (randomPowerUp1 == 0)
            {
                return powerUps[2];
            }
            else if (randomPowerUp1 == 1)
            {
                return powerUps[3];
            }
            else
            {
                return powerUps[4];
            }
        }
        else
        {
            int randomPowerUp2 = Random.Range(0, 2);
            if (randomPowerUp2 == 0)
            {
                return powerUps[3];
            }
            else
            {
                return powerUps[4];
            }
        }
    }
}
