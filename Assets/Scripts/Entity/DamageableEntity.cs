using ObjectsPool;
using UnityEngine;

public class DamageableEntity : MonoBehaviour , IGotHit, IPoolable
{
    [SerializeField] private FloatReference life;
    [SerializeField] private float radiusSize;
    
    protected BulletDetectorManager bulletDetectorManager;

    public float RadiusSize => radiusSize;
    
    public virtual void Awake()
    {
        // ------Testing
        bulletDetectorManager = FindObjectOfType<BulletDetectorManager>();
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
            GodPool.Instance.ReturnPoolObject(this.gameObject);
        }
    }

    public void Init()
    {
        bulletDetectorManager.AddDamageableEntity(this);
    }

    public void Dispose()
    {
        bulletDetectorManager.RemoveDamageableEntity(this);
    }
}