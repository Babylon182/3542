using UnityEngine;

public class EnemyMovement : EntityMovement
{
    public override void Move(Vector3 destination)
    {
        transform.position += destination * Time.deltaTime * speed;
    }

    private void Update()
    {
        var destination = transform.forward;
        Move(destination);
    }
}
