using CalongeCore.ObjectsPool;
using UnityEngine;

public class DamageableEntity : MonoBehaviour , ICanCollide, IPoolable
{
    [SerializeField] protected EntityType afiliation;
    [SerializeField] private FloatReference life;
    [SerializeField] private float radiusSize;
    
    protected CollisionDetectorManager collisionDetectorManager;
   
    public EntityType Afiliation => afiliation;
    public float RadiusSize => radiusSize;
    
    public virtual void Awake()
    {
        // ------Testing
        collisionDetectorManager = FindObjectOfType<CollisionDetectorManager>();
        // -------------
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position , radiusSize);
    }

    public void GotDamaged(float damage)
    {
        life.Value -= damage;
        if (life.Value <= 0)
        {
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