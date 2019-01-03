using CalongeCore.Events;
using CalongeCore.ParticleManager;
using UnityEngine;

[RequireComponent(typeof(DamageableEntity))]
public class Enemy : EntityMovement
{
    private void Awake()
    {
        var damageableEntity = GetComponent<DamageableEntity>();
        damageableEntity.onDeath += () => EventsManager.DispatchEvent(new ParticleEvent(PrefabID.EnemyDeath, transform.position, Quaternion.identity));
    }

    public override void Move(Vector3 destination)
    {
        transform.position += destination * Time.deltaTime * speed;
    }

    private void Update()
    {
        var destination = transform.forward;
        Move(destination);
    }
}
