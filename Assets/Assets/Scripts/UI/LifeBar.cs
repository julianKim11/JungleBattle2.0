using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    #region METHODS
    public void ChangeMaxLife(float maxLife)
    {
        slider.maxValue = maxLife;
    }
    public void ChangeActualLife(float currentLife)
    {
        slider.value = currentLife;
    }
    public void InitializeLifeBar(float currentLife)
    {
        ChangeMaxLife(currentLife);
        ChangeActualLife(currentLife);
    }
    #endregion
}