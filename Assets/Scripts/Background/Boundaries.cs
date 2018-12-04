using UnityEngine;

public class Boundaries
{
    public float Width { get; private set; }
    public float LeftBoundary { get; private set; }
    public float RightBoundary { get; private set; }
    public float TopBoundary { get; private set; }
    public float BottomBoundary { get; private set; }

    public void GetBoundaries()
    {
        var mainCamera = Camera.main;
        var leftCoordinates = new Vector3(0, 0, mainCamera.transform.position.y);
        var rightCoordinates = new Vector3(1, 1, mainCamera.transform.position.y);
        
        LeftBoundary = mainCamera.ViewportToWorldPoint(leftCoordinates).x;
        RightBoundary = mainCamera.ViewportToWorldPoint(rightCoordinates).x;
        TopBoundary = mainCamera.ViewportToWorldPoint(rightCoordinates).z;
        BottomBoundary = mainCamera.ViewportToWorldPoint(leftCoordinates).z;

        Width = RightBoundary - LeftBoundary;   
    }
}
