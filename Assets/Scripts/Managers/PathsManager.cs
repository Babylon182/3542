using System;
using System.Collections.Generic;
using UnityEngine;

public class PathsManager : Singleton<PathsManager>
{
    [SerializeField] 
    private PathTuple[] enemyPathsDictionary;
    
    public Dictionary<EnemyType, FullPath[]> pathsDictionary = new Dictionary<EnemyType, FullPath[]>();

    protected override void Awake()
    {
        base.Awake();

        for (int index = enemyPathsDictionary.Length - 1; index >= 0; index--)
        {
            var pathTuple = enemyPathsDictionary[index];
            pathsDictionary.Add(pathTuple.id, pathTuple.fullPaths);
        }
    }
}

[Serializable]
public struct PathTuple
{
    public EnemyType id;
    public FullPath[] fullPaths;
}