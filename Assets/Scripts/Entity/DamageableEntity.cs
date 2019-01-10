using System;
using CalongeCore.ObjectsPool;
using UnityEngine;

public class DamageableEntity : MonoBehaviour , ICanCollide, IPoolable
{
    [SerializeField] protected EntityType afiliation;
    [SerializeField] private FloatReference life;
    [SerializeField] private float radiusSize;
    public Action onDamage;
    public Action onDeath;
    
    protected CollisionDetectorManager collisionDetectorManager;
   
    public EntityType Afiliation => afiliation;
    public float RadiusSize => radiusSize;
    
    public virtual void Awake()
    {
        // ------Testing --- TODO Service Alocator
        collisionDetectorManager = FindObjectOfType<CollisionDetectorManager>();
        // -------------
        
        onDamage += () => { };
        onDeath += () => { };
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
            GodPoolSingleton.Instance.Destroy(this.gameObject);
        }
    }

    public void Init()
    {
        collisionDetectorManager.AddDamageableEntity(this);
    }

    public void Dispose()
    {
        collisionDetectorManager.RemoveDamageableEntity(this);
    }
}