using System.Collections.Generic;
using System.Linq;
using CalongeCore.Events;
using CalongeCore.ObjectsPool;
using CalongeCore.ParticleManager;
using CalongeCore.SoundManager;
using UnityEngine;

[RequireComponent(typeof(DamageableEntity))]
public class Enemy : EntityMovement, IPoolable
{
    private const float THRESHOLD = 0.2f;

    [SerializeField]
    private EnemyType type;

    private List<Vector3> waypoints;
    private FullPath[] paths;
    private int currentIndex = 0;
    private int waypointsLength = 0;
    
    private void Awake()
    {
        waypoints = new List<Vector3>();
        var damageableEntity = GetComponent<DamageableEntity>();
        damageableEntity.onDeath += () => EventsManager.DispatchEvent(new ParticleEvent(PrefabID.EnemyDeath, transform.position, Quaternion.identity));
        damageableEntity.onDeath += () => EventsManager.DispatchEvent(new SoundEvent(SoundID.EnemyDeath, transform.position));
        paths = PathsManager.Instance.pathsDictionary[type];
    }
    
    public void Init()
    {
        
    }

    public void Dispose()
    {
        currentIndex = waypointsLength = 0;
    }
    
    public void SelectRandomPath()
    {
        currentIndex = 0;
        waypoints = paths[Random.Range(0, paths.Length)].AllWaypoints;
        waypointsLength = waypoints.Count;
    }

    public void SelectPath(SpawningLane lane)
    {
        currentIndex = 0;
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
