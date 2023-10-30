using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region PUBLIC_PROPERTIES
    public static UIManager Instance;
    #endregion

    #region PRIVATE_PROPERTIES
    private static UIManager _instance;
    [SerializeField] private LifeBar _lifeBar;
    int currentLife;
    #endregion

    #region UNITY_METHODS
    private void Awake()
    {
        if (_instance != null)
            Destroy(this.gameObject);
        else
            _instance = this;
    }
    #endregion

    #region METHODS
    //public void ChangeActualLife() => _lifeBar.ChangeActualLife(currentLife);
    #endregion
}
