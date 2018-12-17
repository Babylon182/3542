using UnityEngine;

public class HeroWeapon : MonoBehaviour
{
    public Weapon weaponPrimary;
    public Weapon weaponSecondary;

    public void FirePrimary()
    {
        weaponPrimary.Fire();
    }
    
    public void FireSecondary()
    {
        weaponSecondary.Fire();
    }
}