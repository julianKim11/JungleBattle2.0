using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;
public class PlayerOne : MonoBehaviour
{

    [SerializeField] private GameObject win;
    [SerializeField] Transform shootPos;
    [SerializeField] public float maxLife = 550;
    [SerializeField] public float life;
    [SerializeField] public GameObject prefabBullet;
    [SerializeField] public float vel = 4f;
    [SerializeField] public float jumpForce = 9.5f;
    [SerializeField] public float jumpForceDamage = 0.01f;
    public Image lifeBar1;
    public float heal = 100;
    bool isJumping = false;
    Rigidbody2D rb2d;
    Animator anim;
    public event EventHandler GenerateEnemies;
    public event EventHandler GenerateBox;
    public event EventHandler DiePlayer;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        life = maxLife;
    }

    void Update()
    {
        if(GameManager.Instance.p2 == 0 && GameManager.Instance.pauseState == false)
        {
            MovementControl();
            JumpControl();
            AttackControl();
            LifeBar();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            isJumping = false;
            anim.SetBool("isJumping", isJumping);
            anim.SetBool("TakingDamage", false);
        }
    }
    public void LifeBar()
    {
        lifeBar1.fillAmount = life / maxLife;
        //if(life == 0)
    }
    public void Shoot()
    {
        Instantiate(prefabBullet, shootPos.position, transform.rotation);
    }
    public void MovementControl()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.Translate(vel * Time.deltaTime, 0, 0);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.Translate(vel * Time.deltaTime, 0, 0);
            anim.SetBool("isWalking", true);
        }
    }
    public void JumpControl()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            SoundManager.Instance.PlaySound("Jump");
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            anim.SetBool("isJumping", isJumping);
            if(GameManager.Instance.enemyCountSpawn == 2)
            {
                GenerateEnemies?.Invoke(this, EventArgs.Empty);
            } else if (GameManager.Instance.enemyCountSpawn == 4)
            {
                GenerateBox?.Invoke(this, EventArgs.Empty);
            }
            GameManager.Instance.enemyCountSpawn++;
        }
    }
    public void AttackControl()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SoundManager.Instance.PlaySound("Shoot");
            anim.SetTrigger("RangeAttack");
        }
    }

    public void TakingDamage(float damage)
    {
        SoundManager.Instance.PlaySound("TakingDamage");
        anim.SetBool("TakingDamage", true);
        life -= damage;
        if (life <= 0)
        {
            GameManager.Instance.pause = 0;
            GameManager.Instance.p1++;
            GameManager.Instance.DesactivarTemporizador();
            DiePlayer?.Invoke(this, EventArgs.Empty);
            win.SetActive(true);
            Dead();
        }
        rb2d.AddForce(Vector2.up * jumpForceDamage, ForceMode2D.Impulse); 
        //rb2d.AddForce(Vector2.right * jumpForceDamage, ForceMode2D.Impulse);
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
    public void Heal()
    {
        SoundManager.Instance.PlaySound("Banana");
        life += 100;
        if((life + heal) > maxLife)
        {
            life = maxLife;
        } else
        {
            life += heal;
        }
    }
    public void Watermelon()
    {
        vel += 4;
    }
}
