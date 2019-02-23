using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesDictionary")]
public class EnemiesDictionary : ScriptableObject
{
    public EnemyTuple[] allEnemiesTuples;
}

[Serializable]
public struct EnemyTuple
{
    public EnemyType id;
    public GameObject prefab;
}

