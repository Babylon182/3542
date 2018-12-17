using CalongeCore.ObjectsPool;
using UnityEngine;

public abstract class Bullet : MonoBehaviour , ICanCollide, IPoolable
{
    [SerializeField] protected EntityType afiliation;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    [SerializeField] protected float radiusSize;
    
    private CollisionDetectorManager collisionDetectorManager;

    public EntityType Afiliation => afiliation;
    public float RadiusSize => radiusSize;
    public float Damage => damage;

    public void GotDamaged(float damaged)
    {
        GodPoolSingleton.Instance.Destroy(this.gameObject);
    }

    protected abstract void Movement();

    public virtual void Awake()
    {
        // ------Testing
        collisionDetectorManager = FindObjectOfType<CollisionDetectorManager>();
        //--------------
    }

    public virtual void Update()
    {
        Movement();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position , radiusSize);
    }

    public void Init()
    {
        collisionDetectorManager.AddBullet(this);
    }

    public void Dispose()
    {
        collisionDetectorManager.RemoveBullet(this);
    }
}