using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : BasicObject
{

    private int _damage;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.layer == 14)
        {
            _damage = collision.GetComponent<BasicBullet>()._damage;
            TakeDamage(_damage);
        }

    }

    public override void TakeDamage(int damage)
    {
        //SoundManager.Instance.PlaySound("TakingDamage");
        _currentLife -= damage;
        if (_currentLife <= 0)
        {
            Die();
        }
    }
}
