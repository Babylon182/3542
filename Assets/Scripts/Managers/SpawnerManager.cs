using System.Collections.Generic;
using CalongeCore.ObjectsPool;
using MEC;
using UnityEngine;

public class SpawnerManager : Singleton<SpawnerManager>
{
    [SerializeField]
    private EnemiesDictionary enemiesDictionary;
    
    [SerializeField] 
    private RoundsDictionary roundsDictionary;

    [SerializeField] 
    private float initialOffset;
    
    private Dictionary<EnemyType, GameObject> allEnemies = new Dictionary<EnemyType, GameObject>();
    private float[] spawningPositions;
    private int currentRoundIndex;
    private int currentWaveIndex;

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
        spawnerPosition.z = boundaries.TopBoundary + initialOffset;
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
        var wave = round.waves[currentWaveIndex];
        var spawnPosition = transform.position;
        spawnPosition.x = spawningPositions[(int) wave.spawningLane];
        
        Enemy enemySpawned = GodPoolSingleton.Instance.Instantiate<Enemy>(allEnemies[wave.enemyType].gameObject, spawnPosition , transform.rotation);
        enemySpawned.SelectPath(wave.spawningLane);
    }

    private void ResetRounds()
    {
        currentWaveIndex = currentRoundIndex = 0;
    }

    private IEnumerator<float> SpawnRound()
    {
        var unitsSpawned = 0;
        
        while (true)
        {
            Round round = roundsDictionary.gameRounds[currentRoundIndex];
            Wave currentWave = round.waves[currentWaveIndex];
            SpawnEnemy(round);
            yield return Timing.WaitForSeconds(currentWave.spawnRate);
            unitsSpawned++;
            
            // Check if the amount of units reach the amount of the wave 
            if (unitsSpawned >= currentWave.amountOfEnemies)
            {
                unitsSpawned = 0;
                currentWaveIndex++;
                
                // Wait for the next wave
                yield return Timing.WaitForSeconds(currentWave.timeForNextWave);
                
                // If we are at the end of the rounds, start again
                if (currentWaveIndex >= round.waves.Length && 
                    ++currentRoundIndex >= roundsDictionary.gameRounds.Length)
                {
                    ResetRounds();
                }
            }
        }
    }
}