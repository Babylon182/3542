using UnityEngine;

public class Boundaries
{
    private float width;
    private float leftBoundary;
    private float rightBoundary;

    public float Width => width;
    public float LeftBoundary => leftBoundary;
    public float RightBoundary => rightBoundary;

    public void GetBoundaries()
    {
        var mainCamera = Camera.main;
        var leftCoordinates = new Vector3(0, 0, mainCamera.transform.position.y);
        var rightCoordinates = new Vector3(1, 1, mainCamera.transform.position.y);
        
        leftBoundary = mainCamera.ViewportToWorldPoint(leftCoordinates).x;
        rightBoundary = mainCamera.ViewportToWorldPoint(rightCoordinates).x;

        width = rightBoundary - leftBoundary;   
    }
}
