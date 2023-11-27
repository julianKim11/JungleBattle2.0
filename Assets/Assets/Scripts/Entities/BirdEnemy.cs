using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy : Enemies
{
    
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float minDistance;
    private int random;
    private SpriteRenderer spriteRenderer;
    private int _damage;
    private float _moveSpeed;

    private void Start()
    {
        random = Random.Range(0, movePoints.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        _moveSpeed = _stats.MovementSpeed;
        _damage = _stats.Damage;
        _currentLife = _stats.MaxLife;
        Girar();
    }
    public override void FixedUpdate()
    {
        
    }
    public override void Update()
    {
        RandomMovement();   
    }
    public void RandomMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoints[random].position, _moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePoints[random].position) < minDistance)
        {
            random = Random.Range(0, movePoints.Length);
            Girar();
        }
    }

    public void Girar()
    {
        if (transform.position.x < movePoints[random].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    public override void TakeDamage(int damage)
    {
        _currentLife -= damage;
        if (_currentLife <= 0)
        {
            Die();
        }
    }
    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player1"))
        {
            other.gameObject.GetComponent<Character>().TakeDamage(_damage);
        }
        if (other.collider.CompareTag("Player2"))
        {
            other.gameObject.GetComponent<Character>().TakeDamage(_damage);
        }
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
}
