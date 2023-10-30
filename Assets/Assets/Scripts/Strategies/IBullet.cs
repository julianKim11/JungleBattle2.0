using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet : IProduct
{
    #region PROPERTIES
    float LifeTime { get; }
    LayerMask HitteableLayer { get; }
    #endregion

    #region METHODS
    void Init();
    void OnTriggerEnter2D(Collider2D collision);
    #endregion
}
