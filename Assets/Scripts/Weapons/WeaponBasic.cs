using CalongeCore.Events;
using CalongeCore.ObjectsPool;
using CalongeCore.SoundManager;

public class WeaponBasic : Weapon
{
    protected override void CreateBullet()
    {
        GodPoolSingleton.Instance.Instantiate(weaponData.bullet.gameObject, transform.position, transform.rotation);
        //EventsManager.DispatchEvent(new SoundEvent(SoundID.HeroBasicWeapon, transform.position));
        EventsManager.DispatchEvent<SoundEvent>( soundEvent =>
        {
            soundEvent.id = SoundID.HeroBasicWeapon;
            soundEvent.position = transform.position;
        });
    }
}
