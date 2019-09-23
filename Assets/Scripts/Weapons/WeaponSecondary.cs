using CalongeCore.Events;
using CalongeCore.ObjectsPool;
using CalongeCore.SoundManager;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSecondary : Weapon
{
    [SerializeField]
    protected Image canvasImage;

    public override void Update()
    {
        base.Update();
        canvasImage.fillAmount = currentTime / weaponData.rateOfFire;
    }

    protected override void CreateBullet()
    {
        GodPoolSingleton.Instance.Instantiate(weaponData.bullet.gameObject, transform.position, transform.rotation);
        //EventsManager.DispatchEvent(new SoundEvent(SoundID.HeroBasicWeapon, transform.position));
        EventsManager.DispatchEvent<SoundEvent>(soundEvent =>
        {
            soundEvent.id = SoundID.HeroBasicWeapon;
            soundEvent.position = transform.position;
        });
    }
}
