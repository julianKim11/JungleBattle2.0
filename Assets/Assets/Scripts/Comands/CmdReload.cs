using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdReload : IComand
{
    private IWeapon _weapon;

    public CmdReload(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void Do()
    {
        _weapon.Reload();
    }

    public void UnDo()
    {

    }
}
