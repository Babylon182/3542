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

    private void FixedUpdate()
    {
        heroMovement.Move();
    }

    private void HeroInputs()
    {
        #region Movement Input
        if (InputController.GetKey(GameInputs.Forward))
        {
            heroMovement.SetDirection(transform.forward);
        }
        else if (InputController.GetKey(GameInputs.Backward))
        {
            heroMovement.SetDirection(-transform.forward);
        }

        if (InputController.GetKey(GameInputs.Right))
        {
            heroMovement.SetDirection(transform.right);
        }
        else if (InputController.GetKey(GameInputs.Left))
        {
            heroMovement.SetDirection(-transform.right);
        }
        #endregion
        
        #region Shoot Input
        if (InputController.GetKey(GameInputs.Fire))
        {
            heroWeapon.Fire();
        }
        #endregion
    }
}