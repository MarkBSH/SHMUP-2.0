using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyGroup : ScriptableObject
{
    public List<GameObject> Enemies = new();
}
