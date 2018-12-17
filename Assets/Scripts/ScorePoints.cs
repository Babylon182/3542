using CalongeCore.Events;
using CalongeCore.ScoreManager;
using UnityEngine;

public class ScorePoints : MonoBehaviour
{
    [SerializeField]
    private float scorePoints;
    
    private void OnDisable()
    {
        EventsManager.DispatchEvent(new ScoreEvent(scorePoints));
    }
}
