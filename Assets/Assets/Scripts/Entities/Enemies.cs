using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : BasicObject
{
    [SerializeField] float rayCastDist = 1;
    [SerializeField] LayerMask contacts;
    //[SerializeField] LayerMask hitLayer;
    [SerializeField] Transform rayPoint;
    [SerializeField] private float life = 150;
    [SerializeField] private int damage = 100;
    [SerializeField] public float jumpForceDamage = 2f;
    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        _currentLife = MaxLife;
    }

    private void FixedUpdate()
    {
        
        rb2D.velocity = transform.right * MovementSpeed + new Vector3(0, rb2D.velocity.y, 0);
        

    }

    private void Update()
    {
        EnemyMovement();
        
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
        if (collision.transform.gameObject.layer == 12)
        {
            collision.transform.gameObject.GetComponent<Character>().TakeDamage(damage);
        }
        if (collision.transform.gameObject.layer == 13)
        {
            collision.transform.gameObject.GetComponent<Character>().TakeDamage(damage);
        }
    }
    public override void TakeDamage(int damage)
    {
        //SoundManager.Instance.PlaySound("TakingDamage");
        _currentLife -= damage;
        if(_currentLife <= 0)
        {
            Die();
        }
        rb2D.AddForce(Vector2.up * jumpForceDamage, ForceMode2D.Impulse);
        rb2D.AddForce(Vector2.right * jumpForceDamage, ForceMode2D.Impulse);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.blue;
        Gizmos.DrawLine(rayPoint.position, rayPoint.position - transform.up);
    }
}
