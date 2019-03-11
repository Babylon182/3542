using System;
using CalongeCore.ObjectsPool;
using UnityEngine;

public class DamageableEntity : MonoBehaviour , ICanCollide, IPoolable
{
    [SerializeField] 
    protected EntityType affiliation;
    
    [SerializeField] 
    private FloatReference life;
    
    [SerializeField] 
    private float radiusSize;
    
    public Action onDamage;
    public Action onDeath;
   
    public EntityType Afiliation => affiliation;
    public float RadiusSize => radiusSize;
    
    public void Awake()
    { 
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
        CollisionDetectorManager.Instance.AddDamageableEntity(this);
    }

    public void Dispose()
    {
        CollisionDetectorManager.Instance.RemoveDamageableEntity(this);
    }
}