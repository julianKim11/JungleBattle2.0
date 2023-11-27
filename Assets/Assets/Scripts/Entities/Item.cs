using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemStats _itemStats;
    [SerializeField] private bool _canDamage = false;
    [SerializeField] private bool _canHeal = false;
    [SerializeField] private bool _canSlow = false;
    [SerializeField] private bool _canSpeedUp = false;
    private int _damage => _itemStats.Damage;
    private int _heal => _itemStats.Heal;
    private int _movementSpeed => _itemStats.MinusSpeed;
    private int _movementSpeedUp => _itemStats.MoreSpeed;
    private int _damageUp => _itemStats.PlusDamage;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.layer == 12)
        {
            if (_canDamage)
                collision.transform.gameObject.GetComponent<Character>().SendDamage(true, _damage);
            if (_canHeal)
                collision.transform.gameObject.GetComponent<Character>().Heal(_heal);
            if (_canSlow)
                collision.transform.gameObject.GetComponent<Character>().ChangeMinusSpeed(true, _movementSpeed);
            if (_canSpeedUp)
                collision.transform.gameObject.GetComponent<Character>().ChangeMoreSpeed(_movementSpeedUp);
            ItemEat();
        }
        if (collision.transform.gameObject.layer == 13)
        {
            if (_canDamage)
                collision.transform.gameObject.GetComponent<Character>().SendDamage(false, _damage);
            if (_canHeal)
                collision.transform.gameObject.GetComponent<Character>().Heal(_heal);
            if (_canSlow)
                collision.transform.gameObject.GetComponent<Character>().ChangeMinusSpeed(false, _movementSpeed);
            if (_canSpeedUp)
                collision.transform.gameObject.GetComponent<Character>().ChangeMoreSpeed(_movementSpeedUp);
            ItemEat();
        }
    }
    public void ItemEat()
    {
        Destroy(gameObject);
    }
}