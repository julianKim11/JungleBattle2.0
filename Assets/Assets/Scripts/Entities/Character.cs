using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Actor
{
    #region PUBLIC_PROPERTIES
    [SerializeField] public GameObject prefabBullet;
    [SerializeField] Transform shootPos;
    [SerializeField] public float jumpForce = 9.5f;
    [SerializeField] public float jumpForceDamage = 0.01f;
    public float MovementSpeed => _stats.MovementSpeed;
    bool isJumping = false;
    Rigidbody2D rb2d;
    Animator anim;

    #endregion


    #region KEY_BINDING
    [SerializeField] private KeyCode _jump= KeyCode.W;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;

    [SerializeField] private KeyCode _attack = KeyCode.Mouse0;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
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
        Destroy(bullet, 2f);
    }

    public void MovementControl()
    {
        if (Input.GetKey(_moveRight))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.Translate(MovementSpeed * Time.deltaTime, 0, 0);
            //anim.SetBool("isWalking", true);
        }
        else
        {
            //anim.SetBool("isWalking", false);
        }
        if (Input.GetKey(_moveLeft))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.Translate(MovementSpeed * Time.deltaTime, 0, 0);
            //anim.SetBool("isWalking", true);
        }
    }

    public void JumpControl()
    {
        if (Input.GetKey(_jump))
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
        if (Input.GetKeyDown(_attack))
        {
            Shoot();
           //SoundManager.Instance.PlaySound("Shoot");
           //anim.SetTrigger("RangeAttack");
        }
    }

}
