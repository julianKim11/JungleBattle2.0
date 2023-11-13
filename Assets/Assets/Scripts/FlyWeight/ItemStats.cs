using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemStats")]
public class ItemStats : ScriptableObject
{
    [field: SerializeField] public int Damage { get; private set; } = 10;


    [SerializeField] private ItemStatValues _stats;

    public float MovementSpeed => _stats.MovementSpeed;
}

[System.Serializable]
public struct ItemStatValues
{
    public float MovementSpeed;
}
