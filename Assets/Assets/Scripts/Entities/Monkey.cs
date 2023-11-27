using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : Enemies
{
    public Transform ShootPos;
    public float LineDistance;
    public LayerMask Player;
    public bool PlayerInRange;
    public GameObject EnemyBullet;
    public float TimeBetweenShoots;
    public float TimeLastShoot;

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public override void Update()
    {
        base.Update();
        PlayerInRange = Physics2D.Raycast(ShootPos.position, transform.right, LineDistance, Player);
        if (PlayerInRange)
        {
            if(Time.time > TimeBetweenShoots + TimeLastShoot)
            {
                TimeLastShoot = Time.time;
                Shoot();
            }
        }
    }
    private void Shoot()
    {
        Instantiate(EnemyBullet, ShootPos.position, ShootPos.rotation);
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(ShootPos.position, ShootPos.position + transform.right * LineDistance);
    //}
}
