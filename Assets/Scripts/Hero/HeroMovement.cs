using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody rg;
    private Vector3 direction;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        if (direction == Vector3.zero)
            return;

        rg.MovePosition(transform.position + direction.normalized * speed * Time.deltaTime);
        direction = Vector3.zero;
    }

    public void SetDirection(Vector3 dir)
    {
        direction += dir;
    }
}