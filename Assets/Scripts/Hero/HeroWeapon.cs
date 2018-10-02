using UnityEngine;

public class HeroWeapon : MonoBehaviour
{
    public Weapon weapon;

    public void Fire()
    {
        weapon.Fire();
    }
}