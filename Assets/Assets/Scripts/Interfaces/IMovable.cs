using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    #region PROPERTIES
    float MovementSpeed { get; }
    #endregion

    #region KEY_BINDING
    KeyCode MoveUp { get; }
    KeyCode MoveRight { get; }
    KeyCode MoveLeft { get; }
    #endregion

    #region METHODS
    void Move(Vector3 direction);
    #endregion
}
