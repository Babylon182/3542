using UnityEngine;

[ExecuteInEditMode]
public class GameGizmosHelper : MonoBehaviour
{
    [SerializeField]
    private Vector3 topLeft;
    
    [SerializeField]
    private Vector3 topRight;
    
    [SerializeField]
    private Vector3 bottomLeft;
    
    [SerializeField]
    private Vector3 bottomRight; 
    
    private Boundaries boundaries;

    private void OnValidate()
    {
        GetBoundaries();
    }

    private void GetBoundaries()
    {
        boundaries = new Boundaries();
        topLeft = new Vector3(boundaries.LeftBoundary, 0, boundaries.TopBoundary);
        bottomLeft = new Vector3(boundaries.LeftBoundary, 0, boundaries.BottomBoundary);
        topRight = new Vector3(boundaries.RightBoundary, 0, boundaries.TopBoundary);
        bottomRight = new Vector3(boundaries.RightBoundary, 0, boundaries.BottomBoundary);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(topLeft, bottomLeft);
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
    }
}
