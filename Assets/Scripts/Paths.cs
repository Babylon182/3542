using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class Paths : MonoBehaviour
{
    [SerializeField]
    private Transform[] pathCheckpoints;

    private float testingTimer;

    private const float POINTS_IN_GIZMOS = 50f;

    void Update()
    {


        testingTimer += Time.deltaTime;

        
    }

    private void OnDrawGizmos()
    {
        if (pathCheckpoints.Length > 1)
        {
            Gizmos.color = Color.white;
    
            for (int i = pathCheckpoints.Length - 1; i >= 1; i--)
            {
                Gizmos.DrawLine(pathCheckpoints[i].position, pathCheckpoints[i-1].position);
            }
            
            Gizmos.color = Color.blue;
            var P0 = pathCheckpoints[0].position;
            var P1 = pathCheckpoints[1].position;
            var P2 = pathCheckpoints[2].position;
            var P3 = pathCheckpoints[3].position;
                
            //Formula de Bezier
            //(1-t)3 * P0 + 3 * (1-t)2 *  t * P1 + 3 * (1-t) * t2 * P2  +  t3 *  P3
            
            for (int j = 0; j < POINTS_IN_GIZMOS; j++)
            {
                var percent = j / POINTS_IN_GIZMOS;
                var bezier = Mathf.Pow(1 - percent, 3) * P0 + 3 * Mathf.Pow(1 - percent, 2) * percent * P1 +
                              3 * (1 - percent) * Mathf.Pow(percent, 2) * P2 + Mathf.Pow(percent, 3) * P3;
                
                Gizmos.DrawSphere(bezier,0.1f);
            }
            
        } 
    }
}
