using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullPath : MonoBehaviour
{
    private Paths[] fullPath;
    private List<Vector3> allWaypoints = new List<Vector3>();
    public List<Vector3> AllWaypoints => allWaypoints;

    private void Awake()
    {
        fullPath = GetComponentsInChildren<Paths>();

        for (int i = 0, maxLength = fullPath.Length; i < maxLength; i++)
        {
            allWaypoints.AddRange(fullPath[i].CompletePath);
        }
    }
}
