using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
    private int _dead = 200;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            Character character = collision.GetComponent<Character>();
            if (character != null)
                character.TakeDamage(_dead);
            character.Die();
        }
    }
}
