using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{ 
    #region KEY_BINDING
    KeyCode Attack { get; }
    #endregion
}
