using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackPlayerOne : MonoBehaviour
{
    [SerializeField] private float damage = 50;
    [SerializeField] private float vel;

    private void Update()
    {
        transform.Translate(Vector2.right * vel * Time.deltaTime);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemies>().TakingDamage(damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player2"))
        {
            collision.GetComponent<PlayerTwo>().TakingDamage(damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Items"))
        {
            collision.GetComponent<Box>().TakingDamage(damage);
            Destroy(gameObject);
        }
    }
    public void PowerUp()
    {
        damage += 5;
    }
}
