using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    
    protected abstract void Movement();

    public virtual void Update()
    {
        Movement();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        var target = other.GetComponent<DamageableEntity>();
        
        if (target != null)
        {
            target.GotHit = damage;
            Destroy(gameObject);
        }
    }
}