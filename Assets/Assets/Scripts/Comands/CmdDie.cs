using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdDie : IComand
{
    private IDamageable _victim;

    public CmdDie(IDamageable victim)
    {
        _victim = victim;
    }

    public void Do()
    {
        _victim.Die();
    }

    public void UnDo()
    {
        throw new System.NotImplementedException();
    }
}
