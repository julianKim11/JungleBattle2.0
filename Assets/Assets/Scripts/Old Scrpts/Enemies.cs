using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] float vel = 1.5f;
    [SerializeField] float rayCastDist = 1;
    [SerializeField] LayerMask contacts;
    [SerializeField] Transform rayPoint;
    [SerializeField] private float life = 150;
    [SerializeField] private float damage = 100;
    [SerializeField] public float jumpForceDamage = 2f;
    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.pauseState == false)
        {
            rb2D.velocity = transform.right * vel + new Vector3(0, rb2D.velocity.y, 0);
        }
            
    }

    private void Update()
    {
        if(GameManager.Instance.pauseState == false)
        {
            EnemyMovement();
        }
        
    }

    public void EnemyMovement()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, -transform.up, rayCastDist, contacts);
        if (!hit)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.layer == 6)
        {
            collision.transform.gameObject.GetComponent<PlayerOne>().TakingDamage(damage);
        }
        if (collision.transform.gameObject.layer == 7)
        {
            collision.transform.gameObject.GetComponent<PlayerTwo>().TakingDamage(damage);
        }
    }
    public void TakingDamage(float damage)
    {
        SoundManager.Instance.PlaySound("TakingDamage");
        life -= damage;
        if(life <= 0)
        {
            Dead();
        }
        rb2D.AddForce(Vector2.up * jumpForceDamage, ForceMode2D.Impulse);
        rb2D.AddForce(Vector2.right * jumpForceDamage, ForceMode2D.Impulse);
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.blue;
        Gizmos.DrawLine(rayPoint.position, rayPoint.position - transform.up);
    }
}
