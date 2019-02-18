using System.Collections.Generic;
using CalongeCore.Events;
using CalongeCore.ParticleManager;
using CalongeCore.SoundManager;
using UnityEngine;

[RequireComponent(typeof(DamageableEntity))]
public class Enemy : EntityMovement
{
    private const float THRESHOLD = 0.2f;

    [SerializeField]
    private EnemyType type; 
    
    private List<Vector3> waypoints = new List<Vector3>();
    private FullPath[] paths;
    private int currentIndex = 0;
    private int waypointsLength = 0;
    
    private void Awake()
    {
        var damageableEntity = GetComponent<DamageableEntity>();
        damageableEntity.onDeath += () => EventsManager.DispatchEvent(new ParticleEvent(PrefabID.EnemyDeath, transform.position, Quaternion.identity));
        damageableEntity.onDeath += () => EventsManager.DispatchEvent(new SoundEvent(SoundID.EnemyDeath, transform.position));
        paths = PathsManager.Instance.pathsDictionary[type];
    }
    
    public void SelectRandomPath()
    {
        waypoints = paths[Random.Range(0, paths.Length)].AllWaypoints;
        waypointsLength = waypoints.Count;
    }

    public void SelectPath(SpawningLane lane)
    {
        waypoints = paths[(int) lane].AllWaypoints;
        waypointsLength = waypoints.Count;
    }

    public override void Move(Vector3 destination)
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);

        if ((transform.position - destination).magnitude <= THRESHOLD)
        {
            currentIndex++;
        }
    }

    private void Update()
    {
        if (currentIndex < waypointsLength)
        {
            var destination = waypoints[currentIndex];
            Move(destination);    
        }
        else
        {
            Move(transform.position + transform.forward);
        }
    }
}
