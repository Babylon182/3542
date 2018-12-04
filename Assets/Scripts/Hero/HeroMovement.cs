using UnityEngine;

public class HeroMovement : EntityMovement
{
    [SerializeField]
    private float heroSize;

    [Zenject.Inject]
    private Boundaries boundaries;

    private Vector2 sideLimits;
    private Vector2 frontLimits;

    private void Start()
    {
        sideLimits = new Vector2(boundaries.LeftBoundary + heroSize, boundaries.RightBoundary - heroSize);
        frontLimits = new Vector2(boundaries.BottomBoundary + heroSize, boundaries.TopBoundary - heroSize);
    }
    public override void Move(Vector3 destination)
    {
        if (destination == transform.position)
            return;

        destination.x = Mathf.Clamp(destination.x, sideLimits.x, sideLimits.y);
        destination.z = Mathf.Clamp(destination.z, frontLimits.x, frontLimits.y);

        transform.position = Vector3.MoveTowards(transform.position , destination, speed * Time.deltaTime);
    }
}