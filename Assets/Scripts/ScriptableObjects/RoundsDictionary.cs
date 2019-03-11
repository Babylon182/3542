using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RoundsDictionary")]
public class RoundsDictionary : ScriptableObject
{
    public Round[] gameRounds;
}

public enum SpawningLane
{
    Left,
    Center,
    Right,
    AmountOfLanes
}

[Serializable]
public class Round
{
    public Wave[] waves;
}

[Serializable]
public struct Wave
{
    public EnemyType enemyType;
    public SpawningLane spawningLane;
    public int amountOfEnemies;
    public float spawnRate;
    public float timeForNextWave;
}