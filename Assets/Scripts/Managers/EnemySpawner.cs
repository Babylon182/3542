using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject testingEnemy;
    [SerializeField] private int numberOfLanes;
    [SerializeField] private float spawnRate;

    [Zenject.Inject]
    private Boundaries boundaries;

    [Zenject.Inject]
    private IPool pool;
    
    private float[] spawningPositions; 

    private void Awake()
    {
        boundaries.GetBoundaries();
        spawningPositions = new float[numberOfLanes];
        GetSpawningPositions();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void GetSpawningPositions()
    {
        for (int index = 0, length = spawningPositions.Length; index < length; index++)
        {
            // Magia matematica de Guido Calonge.
            var sizeOfLanes = boundaries.Width / numberOfLanes;
            var laneLimit = boundaries.LeftBoundary + (index + 1) * sizeOfLanes;
            var laneStart = boundaries.LeftBoundary + index * sizeOfLanes;
            spawningPositions[index] = laneStart + ((laneLimit - laneStart) / 2);
        }
    }

    private void SpawnEnemy()
    {
        var random = Random.Range(0, numberOfLanes);
        var spawnPosition = transform.position;
        spawnPosition.x = spawningPositions[random];
        
        pool.Instantiate(testingEnemy, spawnPosition , transform.rotation);
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
