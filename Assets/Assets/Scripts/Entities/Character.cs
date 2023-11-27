using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Character : Actor, IAttackable, IDamageable
{
    #region PUBLIC_PROPERTIES
    public KeyCode Attack => _attack;

    public UnityEvent OnDead;

    [SerializeField] public GameObject prefabBullet;
    [SerializeField] public float jumpForce = 9.5f;
    [SerializeField] public float jumpForceDamage = 0.01f;
    public int MinusSpeed;
    public int MoreSpeed;
    public float TimeBetweenShoots;
    public float TimeLastShoot;
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject _playerOne;
    [SerializeField] private GameObject _playerTwo;
    [SerializeField] private Transform shootPos;
    [SerializeField] private Transform Check;
    [SerializeField] private float _radio;
    [SerializeField] private LifeBar _lifeBar;
    [SerializeField] bool isJumping = false;
    Rigidbody2D rb2d;
    #endregion

    #region KEY_BINDING
    [SerializeField] private KeyCode _attack = KeyCode.E;

    #endregion
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _currentLife = MaxLife;
        _lifeBar.InitializeLifeBar(_currentLife);
    }

    void Update()
    {
        MovementControl();
        JumpControl();
        AttackControl();
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(prefabBullet, shootPos.position, transform.rotation);
        Destroy(bullet, 5f);
    }

    public void MovementControl()
    {
        if (Input.GetKey(MoveRight))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.Translate((MovementSpeed - MinusSpeed + MoreSpeed) * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(MoveLeft))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.Translate((MovementSpeed - MinusSpeed + MoreSpeed) * Time.deltaTime, 0, 0);
        }
    }

    public void JumpControl()
    {
        if (Input.GetKeyDown(MoveUp) && isJumping)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        isJumping = Physics2D.OverlapCircle(Check.position, _radio, groundLayer);
    }
    public void AttackControl()
    {
        if (Input.GetKeyDown(Attack))
        {
            if(Time.time > TimeBetweenShoots + TimeLastShoot)
            {
                TimeLastShoot = Time.time;
                Shoot();
            }
        }
    }
    public override void Heal(int heal)
    {
        _currentLife += heal;
        if ((_currentLife + heal) > MaxLife)
        {
            _currentLife = MaxLife;
        }
        else
        {
            _currentLife += heal;
        }
        _lifeBar.ChangeActualLife(_currentLife);
    }
    public override void TakeDamage(int damage)
    {
        _currentLife -= damage;
        _lifeBar.ChangeActualLife(_currentLife);
        if (_currentLife <= 0)
        {
            Die();
            OnDead.Invoke();
        }
    }
    public void SendDamage(bool one, int damage)
    {
        if (one)
        {
            _playerTwo.GetComponent<Character>().TakeDamage(damage);
        } else
        {
            _playerOne.GetComponent<Character>().TakeDamage(damage);
        }
    }
    public void ChangeMinusSpeed(bool one, int speed)
    {
        if (one)
        {
            _playerTwo.GetComponent<Character>().SwitchMinusSpeed(speed);
        }
        else
        {
            _playerOne.GetComponent<Character>().SwitchMinusSpeed(speed);
        }
    }
    public void ChangeMoreSpeed(int speed)
    {
        MoreSpeed = speed;
    }
    public void SwitchMinusSpeed(int speed)
    {
        MinusSpeed = speed;
    }
}