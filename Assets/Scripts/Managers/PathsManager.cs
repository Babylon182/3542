using System.Collections.Generic;
using UnityEngine;

public class PathsManager : Singleton<PathsManager>
{
    [SerializeField]
    private FullPath[] simpleEnemyPaths;
    
    [SerializeField]
    private FullPath[] mediumEnemyPaths;
    
    [SerializeField]
    private FullPath[] largeEnemyPaths;
    
    public Dictionary<EnemyType, FullPath[]> pathsDictionary = new Dictionary<EnemyType, FullPath[]>();

    protected override void Awake()
    {
        base.Awake();
        pathsDictionary.Add(EnemyType.Small, simpleEnemyPaths);
        pathsDictionary.Add(EnemyType.Medium, mediumEnemyPaths);
        pathsDictionary.Add(EnemyType.Large, largeEnemyPaths);
    }
}