using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObject : MonoBehaviour
{
    #region PUBLIC_PROPERTIES
    public int MaxLife => _stats.MaxLife;
    public int CurentLife => _currentLife;
    public float MovementSpeed => _stats.MovementSpeed;
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] protected ActorStats _stats;
    protected int _currentLife;
    #endregion

    public virtual void Die()
    {
        Destroy(gameObject);
    }
    public virtual void TakeDamage(int damage)
    {
    }
    public virtual void Heal(int heal)
    {
    }
}
