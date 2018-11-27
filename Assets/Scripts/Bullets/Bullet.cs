using CalongeCore.ObjectsPool;
using UnityEngine;

public abstract class Bullet : MonoBehaviour , ICanCollide, IPoolable
{
    [SerializeField] protected EntityType afiliation;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    [SerializeField] protected float radiusSize;
    
    private BulletDetectorManager bulletDetectorManager;

    [Zenject.Inject]
    private IPool pool;

    public EntityType Afiliation => afiliation;
    public float RadiusSize => radiusSize;
    public float Damage => damage;

    public void GotDamaged(float damaged)
    {
        pool.Destroy(this.gameObject);
    }

    protected abstract void Movement();

    public virtual void Awake()
    {
        // ------Testing
        bulletDetectorManager = FindObjectOfType<BulletDetectorManager>();
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
        bulletDetectorManager.AddBullet(this);
    }

    public void Dispose()
    {
        bulletDetectorManager.RemoveBullet(this);
    }
}