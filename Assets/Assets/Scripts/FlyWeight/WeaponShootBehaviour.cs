using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Shootbehaviour")]
public class WeaponShootBehaviour : ScriptableObject
{
    public void Shoot(ref int _bulletCount, WeaponStats stats, Transform instantiator, IWeapon shooter)
    {
        if (_bulletCount > 0)
        {
            GameObject bullet = Instantiate(stats.Bullet, instantiator.position, instantiator.rotation);
            //bullet.GetComponent<BasicBullet>().SetOwner(shooter);

            _bulletCount--;
        }
    }
}