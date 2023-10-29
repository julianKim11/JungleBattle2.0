using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdTakeDamage : IComand
{
    private IDamageable _victim;
    private int _damage;

    public CmdTakeDamage( IDamageable victim, int damage)
    {
        _victim = victim;
        _damage = damage;
    }

    public void Do()
    {
        _victim.TakeDamage(_damage);
    }

    public void UnDo()
    {
        _victim.TakeDamage(-_damage);
    }
}
