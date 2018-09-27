using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    private Rigidbody rg;
    private Vector3 direction;
    private float speed;

    private const string HERO_SPEED = "HeroSpeed";

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
    }

    public void SetStats(Dictionary<string, string> stats)
    {
        speed = Convert.ToSingle(stats[HERO_SPEED]);
    }

    public void Move()
    {
        if (direction == Vector3.zero)
            return;

        rg.MovePosition(transform.position + direction.normalized * speed * Time.deltaTime);
        direction = Vector3.zero;
    }

    public void SetDirection(Vector3 dir)
    {
        direction += dir;
    }
}