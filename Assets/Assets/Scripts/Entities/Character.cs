using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : Actor, IAttackable, IDamageable
{
    #region PUBLIC_PROPERTIES
    public KeyCode Attack => _attack;

    public UnityEvent OnDead;

    [SerializeField] public GameObject prefabBullet;
    [SerializeField] public float jumpForce = 9.5f;
    [SerializeField] public float jumpForceDamage = 0.01f;
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] private Transform shootPos;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private LifeBar _lifeBar;
    bool isJumping = false;
    Rigidbody2D rb2d;
    //Animator anim;
    #endregion

    #region KEY_BINDING
    [SerializeField] private KeyCode _attack = KeyCode.E;

    #endregion
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        _currentLife = MaxLife;
        _lifeBar.InitializeLifeBar(_currentLife);
    }

    void Update()
    {
        MovementControl();
        JumpControl();
        AttackControl();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            isJumping = false;
            //anim.SetBool("isJumping", isJumping);
            //anim.SetBool("TakingDamage", false);
        }
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
            transform.Translate(MovementSpeed * Time.deltaTime, 0, 0);
            //anim.SetBool("isWalking", true);
        }
        else
        {
            //anim.SetBool("isWalking", false);
        }
        if (Input.GetKey(MoveLeft))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.Translate(MovementSpeed * Time.deltaTime, 0, 0);
            //anim.SetBool("isWalking", true);
        }
    }

    public void JumpControl()
    {
        if (Input.GetKey(MoveUp))
        {
            if (!isJumping)
            {
                //SoundManager.Instance.PlaySound("Jump");
                rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
                //anim.SetBool("isJumping", isJumping);
                //if (GameManager.Instance.enemyCountSpawn == 2)
                //{
                //    GenerateEnemies?.Invoke(this, EventArgs.Empty);
                //}
                //else if (GameManager.Instance.enemyCountSpawn == 4)
                //{
                //    GenerateBox?.Invoke(this, EventArgs.Empty);
                //}
                //GameManager.Instance.enemyCountSpawn++;
            }
        }
    }

    public void AttackControl()
    {
        if (Input.GetKeyDown(Attack))
        {
            Shoot();
           //SoundManager.Instance.PlaySound("Shoot");
           //anim.SetTrigger("RangeAttack");
        }
    }
    public override void Heal()
    {
        //SoundManager.Instance.PlaySound("Banana");
        //_currentLife += 100;
        //if ((_currentLife + heal) > MaxLife)
        //{
        //    _currentLife = MaxLife;
        //}
        //else
        //{
        //    _currentLife += heal;
        //}
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
}