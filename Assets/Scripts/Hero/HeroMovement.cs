using UnityEngine;

public class HeroMovement : EntityMovement
{
    private Rigidbody rg;

    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
    }

    public override void Move()
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