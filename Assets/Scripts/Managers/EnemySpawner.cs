using System.Collections;
using CalongeCore.ObjectsPool;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject testingEnemy;
    
    [SerializeField] 
    private int numberOfLanes;
    
    [SerializeField] 
    private float spawnRate;
    
    private float[] spawningPositions; 

    private void Awake()
    {
        spawningPositions = new float[numberOfLanes];
        GetSpawningPositions();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void GetSpawningPositions()
    {
        var boundaries = new Boundaries();
        var spawnerPosition = transform.position;
        spawnerPosition.z = boundaries.TopBoundary;
        spawnerPosition.x = boundaries.LeftBoundary + (boundaries.LeftBoundary + boundaries.RightBoundary) / 2;
        
        transform.position = spawnerPosition;
        
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
        
        GodPoolSingleton.Instance.Instantiate(testingEnemy, spawnPosition , transform.rotation);
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
