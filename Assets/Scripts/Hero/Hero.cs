using UnityEngine;

public class Hero : EntityMovement, ICanCollide
{
    [SerializeField] 
    private float radiusSize;
    [SerializeField]
    protected EntityType afiliation;

    [Zenject.Inject] 
    private Boundaries boundaries;

    private Vector2 sideLimits;
    private Vector2 frontLimits;
    private HeroWeapon heroWeapon;

    public float RadiusSize => radiusSize;
    public EntityType Afiliation => afiliation;


    private void Awake()
    {
        InputController.Initialize(); //TODO Buscar una MUCHA mejor manera de llamar a esto. LIKE INJECT pero cuando tenga ganas
        heroWeapon = gameObject.GetComponent<HeroWeapon>();
    }

    private void Start()
    {
        sideLimits = new Vector2(boundaries.LeftBoundary + radiusSize, boundaries.RightBoundary - radiusSize);
        frontLimits = new Vector2(boundaries.BottomBoundary + radiusSize, boundaries.TopBoundary - radiusSize);
    }

    private void Update()
    {
        HeroInputs();
    }

    private void HeroInputs()
    {
        MovementInputs();
        ShootInputs();
    }

    public void GotDamaged(float damage = 0)
    {
        transform.position = Vector3.zero;
    }

    public override void Move(Vector3 destination)
    {
        if (destination == transform.position)
            return;

        destination.x = Mathf.Clamp(destination.x, sideLimits.x, sideLimits.y);
        destination.z = Mathf.Clamp(destination.z, frontLimits.x, frontLimits.y);

        transform.position = Vector3.MoveTowards(transform.position , destination, speed * Time.deltaTime);
    }

    private void MovementInputs()
    {
        var plane = new Plane(Vector3.up, transform.position);
        
#if UNITY_EDITOR
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
#elif UNITY_ANDROID || UNITY_IOS
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
#endif
        
        float enter = 0.0f;
        if (plane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Move(hitPoint);
        }
    }

    private void ShootInputs()
    {
        if (InputController.GetKey(GameInputs.Fire))
        {
            heroWeapon.Fire();
        }
    }
}