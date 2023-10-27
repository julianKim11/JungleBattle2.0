using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float minDistance;
    private int random;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        random = Random.Range(0, movePoints.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Girar();
    }

    void Update()
    {
        if (GameManager.Instance.pauseState == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, movePoints[random].position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, movePoints[random].position) < minDistance)
            {
                random = Random.Range(0, movePoints.Length);
                Girar();
            }
        }
    }

    public void Girar()
    {
        if(transform.position.x < movePoints[random].position.x)
        {
            spriteRenderer.flipX = true;
        } else
        {
            spriteRenderer.flipX = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player1"))
        {
            other.gameObject.GetComponent<PlayerOne>().TakingDamage(600);
        }
        if (other.collider.CompareTag("Player2"))
        {
            other.gameObject.GetComponent<PlayerTwo>().TakingDamage(600);
        }
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
}
