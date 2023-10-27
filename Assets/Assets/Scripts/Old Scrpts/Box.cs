using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private float life = 400;
    public void TakingDamage(float damage)
    {
        SoundManager.Instance.PlaySound("TakingDamage");
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
