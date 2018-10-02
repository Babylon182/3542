using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected float speed;
    protected float damage;
    
    public abstract void Movement();
    public abstract void Damage();

    public virtual void Update()
    {
        Movement();
    }

    protected void OnTriggerEnter(Collider other)
    {
        
    }
}
