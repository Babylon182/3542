using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyMovement : MonoBehaviour
{
    public float speed;

	void Update ()
    {
        transform.position += new Vector3(0,0, -speed*Time.deltaTime);
	}
}
