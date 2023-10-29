using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, IDamageable
{
    #region     PUBLIC_PROPERTIES
    public int MaxLife => _stats.MaxLife;

    public int CurentLife => _currentLife;
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] protected ActorStats _stats;
    private CmdDie _cmdDie;
    private int _currentLife;
    #endregion
    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        _currentLife -= damage;
        if (_currentLife <= 0)
        {
            //GameManager.instance.AddEvents(_cmdDie);
            Die();
        }
    }
}
