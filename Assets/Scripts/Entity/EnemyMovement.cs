using UnityEngine;

public class EnemyMovement : EntityMovement
{
    public override void Move()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void Update()
    {
        Move();
    }
}
