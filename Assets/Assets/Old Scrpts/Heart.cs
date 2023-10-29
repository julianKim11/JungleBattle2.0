using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<PlayerOne>().Heal();
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<PlayerTwo>().Heal();
            Destroy(gameObject);
        }
    }
}
