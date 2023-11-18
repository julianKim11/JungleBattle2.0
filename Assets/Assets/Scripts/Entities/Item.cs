using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField] ItemStats _itemStats;

    [SerializeField] private bool _canDamage = false;

    [SerializeField] private bool _canSlow = false;
    private int _damage => _itemStats.Damage;
    private float _movementSpeed => _itemStats.MovementSpeed;
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
        if (collision.transform.gameObject.layer == 12 || collision.transform.gameObject.layer == 13)
        {
            if (_canDamage == true)
            {
                collision.transform.gameObject.GetComponent<Character>().TakeDamage(_damage);
                Destroy(gameObject);
            }

            //else if (_canSlow == true)
            //{
            //    collision.transform.gameObject.GetComponent<Character>().MovementSpeed += 
            //}

        }

    }
}
