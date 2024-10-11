using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Wave : ScriptableObject
{
    public List<EnemyGroup> enemyGroups = new();
}
