using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : BasicObject
{
    public int Damage => _stats.Damage;

    [SerializeField] float rayCastDist = 1;
    [SerializeField] LayerMask contacts;
    //[SerializeField] LayerMask hitLayer;
    [SerializeField] Transform rayPoint;
    [SerializeField] public float jumpForceDamage = 2f;
    public int SpeedUp = 0;
    
    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        _currentLife = MaxLife;
    }

    public virtual void FixedUpdate()
    {
        rb2D.velocity = transform.right * (MovementSpeed + SpeedUp) + new Vector3(0, rb2D.velocity.y, 0);
    }

    public virtual void Update()
    {
        EnemyMovement();
    }
    public virtual void EnemyMovement()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, -transform.up, rayCastDist, contacts);
        if (!hit)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.layer == 12)
        {
            collision.transform.gameObject.GetComponent<Character>().TakeDamage(Damage);
        }
       
        if (collision.transform.gameObject.layer == 13)
        {
            collision.transform.gameObject.GetComponent<Character>().TakeDamage(Damage);
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

    public void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.blue;
        Gizmos.DrawLine(rayPoint.position, rayPoint.position - transform.up);
    }
}
