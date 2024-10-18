using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyWeapon : ScriptableObject
{
    public int projectileCount;
    public int damage;
    public bool spreadShot;
    public int spreadArc;
    public GameObject bulletObj;
}
