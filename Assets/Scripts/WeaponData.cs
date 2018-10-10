using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/WeaponData")]
public class WeaponData : ScriptableObject 
{
	public Bullet bullet;
	public WeaponType weaponType;
	public float rateOfFire;
}
