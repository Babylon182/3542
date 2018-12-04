using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[RequireComponent(typeof(HeroMovement), typeof(HeroWeapon))]
public class HeroController : MonoBehaviour
{
    private HeroMovement heroMovement;
    private HeroWeapon heroWeapon;

    private void Awake()
    {
        InputController.Initialize(); //TODO Buscar una MUCHA mejor manera de llamar a esto.
        Initialize();
    }

    private void Initialize()
    {
        heroMovement = gameObject.GetComponent<HeroMovement>();
        heroWeapon = gameObject.GetComponent<HeroWeapon>();
    }

    void Update()
    {
        HeroInputs();
    }

    private void HeroInputs()
    {
        MovementInputs();
        ShootInputs();
    }

    private void MovementInputs()
    {
        var plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;
        if (plane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            heroMovement.Move(hitPoint);
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