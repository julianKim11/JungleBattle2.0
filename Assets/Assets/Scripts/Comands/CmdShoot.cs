using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdShoot : IComand
{
    private IWeapon _weapon;

    public CmdShoot(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void Do() => _weapon.Attack();

    public void UnDo()
    {
        //to do 
    }
}
