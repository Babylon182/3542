using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour , IInitializable
{
    private const string RATE_OF_FIRE = "rateOfFire";

    [SerializeField] protected Bullet bullet;
    [SerializeField] protected WeaponType weaponType;
    protected float rateOfFire;
    
    private float currentTime;

    public abstract void CreateBullet();

    public virtual void Update()
    {
        currentTime += Time.deltaTime;
    }
    
    public virtual void Fire()
    {
        if (!CanShoot())
            return;
        
        CreateBullet();
        currentTime = 0;
    }
    
    protected bool CanShoot()
    {
        return currentTime > rateOfFire;
    }

    public void Initialize(Dictionary<string, object> data)
    {
        var weaponData = (Dictionary<string, object>) data[weaponType.ToString()];
        rateOfFire = Convert.ToSingle(weaponData[RATE_OF_FIRE]);

    }
}

public enum WeaponType
{
    Basic,
    TriShot,
    Sinusoidal
}