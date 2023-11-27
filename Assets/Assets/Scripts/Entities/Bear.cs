using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Enemies
{
    public Transform FirstLine;
    public float LineDistance;
    public LayerMask Player;
    public bool PlayerInRange;

    public override void Update()
    {
        base.Update();
        PlayerInRange = Physics2D.Raycast(FirstLine.position, transform.right, LineDistance, Player);
        if (PlayerInRange)
        {
            SpeedUp = 4;
        }
        else
        {
            SpeedUp = 0;
        }
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
}
