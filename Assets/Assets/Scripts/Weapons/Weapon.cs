using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    #region PUBLIC_PROPERTIES
    public WeaponStats WeaponStats => _weaponStats;
    public GameObject Bullet => _weaponStats.Bullet;
    public int Damage => _weaponStats.Damage;
    public static GameObject _firePoint { get; private set; }
    #endregion
    #region PRIVATE_PROPERTIES

    [SerializeField] private WeaponStats _weaponStats;
    [SerializeField] private GameObject FirePoint = _firePoint;

    private BulletFactory bulletFactory;

    #endregion
    void Start()
    {
        BasicBullet bullet = _weaponStats.Bullet.GetComponent<BasicBullet>();
        bulletFactory = new BulletFactory(bullet);
    }

    public void Attack()
    {
        IProduct bullet = bulletFactory.CreateProduct();
        GameObject bulletObject = bullet.MyGameObject;
        bulletObject.transform.position = FirePoint.transform.position;
        bulletObject.transform.rotation = FirePoint.transform.rotation;
        //Destroy(bulletObject, 1f);
    }
}