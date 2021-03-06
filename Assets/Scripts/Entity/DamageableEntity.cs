﻿using System;
using CalongeCore.ObjectsPool;
using UnityEngine;
using UnityEngine.Events;

public class DamageableEntity : MonoBehaviour , ICanCollide, IPoolable
{
    public Action onDamage;
    public Action onDeath;

    [SerializeField] 
    protected EntityType affiliation;
    
    [SerializeField] 
    private FloatReference life;
    
    [SerializeField] 
    private float radiusSize;
    
    [SerializeField]
    private UnityEvent onDestroy;

    private float maxLife;

    public EntityType Afiliation => affiliation;
    public float RadiusSize => radiusSize;
    
    public void Awake()
    {
        maxLife = life.Value;
        onDamage += () => { };
        onDeath  += () => Remove();
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position , radiusSize);
    }

    public void GotDamaged(float damage = 1)
    {
        life.Value -= damage;
        onDamage.Invoke();

        if (life.Value <= 0)
        {
            onDeath.Invoke();
        }
    }

    public void Init()
    {
        CollisionDetectorManager.Instance.AddDamageableEntity(this);
    }

    public void Dispose()
    {
        life.Value = maxLife;
        CollisionDetectorManager.Instance.RemoveDamageableEntity(this);
    }

    public void Remove()
    {
        onDestroy.Invoke();
        GodPoolSingleton.Instance.Destroy(this.gameObject);
    }
}