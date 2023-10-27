using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage = 250;

    private void on(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            collision.GetComponent<PlayerOne>().TakingDamage(damage);
        }
          if (collision.CompareTag("Player2"))
        {
            collision.GetComponent<PlayerTwo>().TakingDamage(damage);
        }
    }
}
