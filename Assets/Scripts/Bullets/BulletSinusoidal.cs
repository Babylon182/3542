using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSinusoidal : Bullet
{
    [SerializeField]
    private float magnitude;
    [SerializeField]
    private float frecuency;

    private float initialPositionX;
    private float timer;

    public override void Init()
    {
        base.Init();
        timer = 0;
        initialPositionX = transform.position.x;
    }

    protected override void Movement()
    {
        timer += Time.deltaTime;
        float sinuMovement = Mathf.Cos(timer * frecuency) * magnitude;
        transform.position += (transform.forward * speed + transform.right * sinuMovement) * Time.deltaTime;
    }
}
