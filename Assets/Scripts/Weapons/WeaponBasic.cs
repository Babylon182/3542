using ObjectsPool;

public class WeaponBasic : Weapon
{
    protected override void CreateBullet()
    {
        GodPool.Instance.InstantiatePoolObject(weaponData.bullet.gameObject, transform.position,transform.rotation);
    }
}
