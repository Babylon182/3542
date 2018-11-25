public class WeaponBasic : Weapon
{
    [Zenject.Inject]
    private IPool pool;
    
    protected override void CreateBullet()
    {
        pool.Instantiate(weaponData.bullet.gameObject, transform.position,transform.rotation);
    }
}
