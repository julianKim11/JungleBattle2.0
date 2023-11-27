using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemStats")]
public class ItemStats : ScriptableObject
{
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int Heal { get; private set; }
    [field: SerializeField] public int MinusSpeed { get; private set; }
    [field: SerializeField] public int MoreSpeed { get; private set; }
    [field: SerializeField] public int PlusDamage { get; private set; }


    [SerializeField] private ItemStatValues _stats;

    public float MovementSpeed => _stats.MovementSpeed;
}

[System.Serializable]
public struct ItemStatValues
{
    public float MovementSpeed;
}
