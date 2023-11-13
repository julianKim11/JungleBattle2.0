using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : Actor, IBullet
{
    public float LifeTime => _lifeTime;
    public LayerMask HitteableLayer => _hitteableLayer;
    public GameObject MyGameObject => _myGameObject;
    [SerializeField] private int _damage;

    #region PRIVATE_PROPERTIES
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private LayerMask _hitteableLayer;
    [SerializeField] private GameObject _myGameObject;
    [SerializeField] private Character _character;

    private Collider2D _collider2D;
    private Rigidbody2D _rb2D;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _rb2D = GetComponent<Rigidbody2D>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0) Destroy(gameObject);
    }
    public IProduct Clone()
    {
        return Instantiate(this);
    }

    public void Init()
    {
        _collider2D.isTrigger = true;
        _rb2D.isKinematic = true;
        _rb2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _hitteableLayer) != 0)
        {
            if (collision.CompareTag("Player1"))
            {
                Character _character = collision.GetComponent<Character>();
                if (_character != null)
                    _character.TakeDamage(_damage);
                Destroy(gameObject);
            }
            if (collision.CompareTag("Player2"))
            {
                Character _character = collision.GetComponent<Character>();
                if (_character != null)
                    _character.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
    public void Move() => transform.Translate(Vector2.right * _movementSpeed * Time.deltaTime);
}