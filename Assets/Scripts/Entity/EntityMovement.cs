using UnityEngine;

public abstract class EntityMovement : MonoBehaviour
{
    [SerializeField] protected float speed; 

    public abstract void Move(Vector3 destination);
    
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
}