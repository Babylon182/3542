using CalongeCore.Events;
using Events;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(DamageableEntity))]
public class Hero : EntityMovement
{
    private Vector2 sideLimits;
    private Vector2 frontLimits;
    private HeroWeapon heroWeapon;
    private DamageableEntity damageableEntity;


    private void Awake()
    {
        damageableEntity = GetComponent<DamageableEntity>();
        InputController.Initialize(); //TODO Buscar una MUCHA mejor manera de llamar a esto. 
        heroWeapon = gameObject.GetComponent<HeroWeapon>();
    }

    private void Start()
    {
        var radiusSize = damageableEntity.RadiusSize;
        var boundaries = new Boundaries();

        sideLimits = new Vector2(boundaries.LeftBoundary + radiusSize, boundaries.RightBoundary - radiusSize);
        frontLimits = new Vector2(boundaries.BottomBoundary + radiusSize, boundaries.TopBoundary - radiusSize);
    }

    private void Update()
    {
        HeroInputs();
    }

    public void GotDamaged(float damage = 0)
    {
        transform.position = Vector3.zero;
        EventsManager.DispatchEvent(new HeroDamaged());
    }

    public override void Move(Vector3 destination)
    {
        if (destination == transform.position)
            return;

        destination.x = Mathf.Clamp(destination.x, sideLimits.x, sideLimits.y);
        destination.z = Mathf.Clamp(destination.z, frontLimits.x, frontLimits.y);

        transform.position = Vector3.MoveTowards(transform.position , destination, speed * Time.deltaTime);
    }

    private void HeroInputs()
    {
        MovementInputs();
        ShootInputs();
    }

    private void MovementInputs()
    {
            
#if UNITY_EDITOR
        if (!EventSystem.current.IsPointerOverGameObject(-1))
        {
            var plane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enter = 0.0f;
            if (plane.Raycast(ray, out enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                Move(hitPoint);
            }
        }
#elif UNITY_ANDROID || UNITY_IOS
        if (!EventSystem.current.IsPointerOverGameObject(0))
        {
            var plane = new Plane(Vector3.up, transform.position);
            


            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            
            float enter = 0.0f;
            if (plane.Raycast(ray, out enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                Move(hitPoint);
            }
        }
#endif
            
        
    }

    private void ShootInputs()
    {
        heroWeapon.FirePrimary();
        
#if UNITY_EDITOR
        if (InputController.GetKey(GameInputs.Fire))
        {
            heroWeapon.FireSecondary();
        }
#endif
    }
}

/*
 private bool IsPointerOverUIObject() {
     PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
     eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
     List<RaycastResult> results = new List<RaycastResult>();
     EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
     return results.Count > 0;
 }
*/