using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : BasicObject
{
    private void Start()
    {
        _currentLife = MaxLife;
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
}
