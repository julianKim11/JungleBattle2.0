using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, IMovable
{
    #region PUBLIC_PROPERTIES
    public int MaxLife => _stats.MaxLife;
    public int CurentLife => _currentLife;
    public float MovementSpeed => _stats.MovementSpeed;
    public KeyCode MoveUp => _moveUp;
    public KeyCode MoveRight => _moveRight;
    public KeyCode MoveLeft => _moveLeft;
    //public int heal = 100;
    #endregion

    #region KEY_BINDING
    [SerializeField] protected KeyCode _moveUp;
    [SerializeField] protected KeyCode _moveLeft;
    [SerializeField] protected KeyCode _moveRight;
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] protected ActorStats _stats;
    //private CmdDie _cmdDie;
    protected int _currentLife;
    #endregion

    #region METHODS
    public virtual void Die()
    {
        Destroy(gameObject);
    }
    public virtual void TakeDamage(int damage)
    {
    }
    public virtual void Heal()
    {
    }
    public virtual void Move(Vector3 direction)
    {
    }
    #endregion
}
