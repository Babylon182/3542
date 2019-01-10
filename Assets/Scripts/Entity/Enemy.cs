using CalongeCore.Events;
using CalongeCore.ParticleManager;
using CalongeCore.SoundManager;
using UnityEngine;

[RequireComponent(typeof(DamageableEntity))]
public class Enemy : EntityMovement
{
    private void Awake()
    {
        var damageableEntity = GetComponent<DamageableEntity>();
        damageableEntity.onDeath += () => EventsManager.DispatchEvent(new ParticleEvent(PrefabID.EnemyDeath, transform.position, Quaternion.identity));
        damageableEntity.onDeath += () => EventsManager.DispatchEvent(new SoundEvent(SoundID.EnemyDeath, transform.position));
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
