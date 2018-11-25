using System.Collections;
using ObjectsPool;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject testingEnemy;
    [SerializeField] private int numberOfLanes;
    [SerializeField] private float spawnRate;

    private float[] spawningPositions; 

    private void Awake()
    {
        spawningPositions = new float[numberOfLanes];
        GetBoundaries();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void GetBoundaries()
    {
        var mainCamera = Camera.main;
        var leftCoordinates = new Vector3(0, 0, mainCamera.transform.position.y);
        var rightCoordinates = new Vector3(1, 1, mainCamera.transform.position.y);
        
        var leftBoundary = mainCamera.ViewportToWorldPoint(leftCoordinates).x;
        var rightBoundary = mainCamera.ViewportToWorldPoint(rightCoordinates).x;

        var width = rightBoundary - leftBoundary;
        var sizeOfLanes = width / numberOfLanes;

        for (int index = 0, length = spawningPositions.Length; index < length; index++)
        {
            // Magia matematica de Guido Calonge.
            var laneLimit = leftBoundary + (index + 1) * sizeOfLanes;
            var laneStart = leftBoundary + index * sizeOfLanes;
            spawningPositions[index] = laneStart + ((laneLimit - laneStart) / 2);
        }
    }

    private void SpawnEnemy()
    {
        var random = Random.Range(0, numberOfLanes);
        var spawnPosition = transform.position;
        spawnPosition.x = spawningPositions[random];
        
        var enemy = GodPool.Instance.InstantiatePoolObject(testingEnemy, spawnPosition , transform.rotation);
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
