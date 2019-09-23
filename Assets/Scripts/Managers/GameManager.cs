using System;
using CalongeCore.Events;
using CalongeCore.PauseManager;
using Events;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Canvas defeatCanvas;
    public Canvas winCanvas;

    protected override void Awake()
    {
        base.Awake();
        EventsManager.SubscribeToEvent<HeroDamaged>(OnHeroDamaged);
    }

    private void OnHeroDamaged(HeroDamaged gameEvent)
    {
        if (gameEvent.currentLife == 0)
        {
            Defeat();
        }
    }

    public void Win()
    {

    }

    public void Defeat()
    {
        PauseManager.Instance.Pause();
        defeatCanvas.gameObject.SetActive(true);
    }
}
