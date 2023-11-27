using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : BasicObject, IMovable
{
    #region PUBLIC_PROPERTIES
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

    #region METHODS
    public virtual void Move(Vector3 direction)
    {
    }
    #endregion
}