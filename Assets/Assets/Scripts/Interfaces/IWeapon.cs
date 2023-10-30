using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    #region PROPERTIES

    WeaponStats WeaponStats { get; }
    GameObject Bullet { get; }
    int Damage { get; }
    #endregion

    #region METHODS
    void Attack();
    #endregion
}
