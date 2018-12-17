using CalongeCore.ObjectsPool;

public class WeaponBasic : Weapon
{
    protected override void CreateBullet()
    {
        GodPoolSingleton.Instance.Instantiate(weaponData.bullet.gameObject, transform.position,transform.rotation);
    }
}
