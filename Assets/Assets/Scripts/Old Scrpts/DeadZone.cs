using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player1"))
        {
            other.gameObject.GetComponent<PlayerOne>().TakingDamage(550);
        }
        if (other.collider.CompareTag("Player2"))
        {
            other.gameObject.GetComponent<PlayerTwo>().TakingDamage(550);
        }
    }
}
