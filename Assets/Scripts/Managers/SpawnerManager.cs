using System;
using System.Collections.Generic;
using CalongeCore.ObjectsPool;
using MEC;
using UnityEngine;

public class SpawnerManager : Singleton<SpawnerManager>
{
    [SerializeField]
    private EnemiesDictionary enemiesDictionary;
    
    [SerializeField] 
    private Round[] gameRounds;
    
    private Dictionary<EnemyType, GameObject> allEnemies = new Dictionary<EnemyType, GameObject>();
    private float[] spawningPositions;
    private int currentRoundIndex;

    protected override void Awake()
    {
        base.Awake();
        spawningPositions = new float[(int) SpawningLane.AmountOfLanes];
        FillDictionary();
        GetSpawningPositions();
    }

    private void Start()
    {
        Timing.RunCoroutine(SpawnRound());
    }
    
    private void FillDictionary()
    {
        for (int i = enemiesDictionary.allEnemiesTuples.Length - 1; i >= 0; i--)
        {
            var currentC = enemiesDictionary.allEnemiesTuples[i];

            if (!allEnemies.ContainsKey(currentC.id))
            {
                allEnemies.Add(currentC.id, currentC.prefab);
            }
        }
    }

    private void GetSpawningPositions()
    {
        var boundaries = new Boundaries();
        var thisTransform = transform;
        
        var spawnerPosition = thisTransform.position;
        spawnerPosition.z = boundaries.TopBoundary;
        spawnerPosition.x = boundaries.LeftBoundary + (boundaries.LeftBoundary + boundaries.RightBoundary) / 2;
        
        thisTransform.position = spawnerPosition;
        thisTransform.Rotate(new Vector3(0,180,0));
        
        for (int index = 0, length = spawningPositions.Length; index < length; index++)
        {
            // Magia matematica de Guido Calonge.
            var sizeOfLanes = boundaries.Width / (int) SpawningLane.AmountOfLanes;
            var laneLimit = boundaries.LeftBoundary + (index + 1) * sizeOfLanes;
            var laneStart = boundaries.LeftBoundary + index * sizeOfLanes;
            spawningPositions[index] = laneStart + ((laneLimit - laneStart) / 2);
        }
    }

    private void SpawnEnemy(Round round)
    {
        var wave = round.waves[round.currentWaveIndex];
        var spawnPosition = transform.position;
        spawnPosition.x = spawningPositions[(int) wave.spawningLane];
        
        var enemySpawned = GodPoolSingleton.Instance.Instantiate(allEnemies[wave.enemyType].gameObject, spawnPosition , transform.rotation);
        enemySpawned.GetComponent<Enemy>().SelectPath(wave.spawningLane);
    }

    private IEnumerator<float> SpawnRound()
    {
        var unitsSpawned = 0;
        
        while (true)
        {
            var round = gameRounds[currentRoundIndex];
            SpawnEnemy(round);
            yield return Timing.WaitForSeconds(round.CurrentWave.spawnRate);
            unitsSpawned++;

            if (unitsSpawned > round.CurrentWave.amountOfEnemies)
            {
                unitsSpawned = 0;
                round.currentWaveIndex++;

                if (round.currentWaveIndex >= round.waves.Length)
                {
                    currentRoundIndex++;
                }
            }
        }
    }
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
    
    [HideInInspector]
    public int currentWaveIndex;

    public Wave CurrentWave => waves[currentWaveIndex];
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