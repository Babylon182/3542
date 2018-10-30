using UnityEngine;

public abstract class EntityMovement : MonoBehaviour
{
    [SerializeField] protected float speed; 
    protected Vector3 direction;

    public abstract void Move();
    
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
}