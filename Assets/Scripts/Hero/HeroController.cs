using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private HeroMovement heroMovement;

    private void Awake()
    {
        InputController.Initialize(); //TODO Buscar una MUCHA mejor manera de llamar a esto.
        Initialize();
        SetHeroStats();
    }

    private void Initialize()
    {
        heroMovement = gameObject.AddComponent<HeroMovement>();
    }

    void Update()
    {
        HeroMovementInputs();
    }

    private void FixedUpdate()
    {
        heroMovement.Move();
    }

    private void HeroMovementInputs()
    {
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
    }

    private void SetHeroStats()
    {
        TextAsset heroStats = Resources.Load<TextAsset>(JsonPath.HERO_STATS_PATH);
        Dictionary<string, object> dictionaryHeroStats = JsonConvert.DeserializeObject<Dictionary<string, object>>(heroStats.text);
        
        heroMovement.Initialize(dictionaryHeroStats);
    }
}