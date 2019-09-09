using CalongeCore.Events;
using CalongeCore.ObjectsPool;
using CalongeCore.SoundManager;
using UnityEngine;

public class WeaponMultiShot : Weapon
{
    [SerializeField]
    private int numberObBullets;

    [SerializeField]
    private int degrees;

    protected override void CreateBullet()
    {
        EventsManager.DispatchEvent<SoundEvent>(soundEvent =>
        {
            soundEvent.id = SoundID.HeroBasicWeapon;
            soundEvent.position = transform.position;
        });

        int count = numberObBullets / 2;
        for (int i = -count; i <= count; i++)
        {
            var rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, i * degrees, 0));
            GodPoolSingleton.Instance.Instantiate(weaponData.bullet.gameObject, transform.position, rotation);
        }
    }
}
