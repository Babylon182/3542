using CalongeCore.Events;
using CalongeCore.ScoreManager;
using UnityEngine;

public class ScorePoints : MonoBehaviour
{
    [SerializeField]
    private float scorePoints;
    
    public void AddScore()
    {
        EventsManager.DispatchEvent(new ScoreEvent(scorePoints));
    }
}
