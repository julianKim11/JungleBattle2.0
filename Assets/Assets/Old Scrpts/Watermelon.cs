using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<PlayerOne>().Watermelon();
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<PlayerTwo>().Watermelon();
            Destroy(gameObject);
        }
    }
}
