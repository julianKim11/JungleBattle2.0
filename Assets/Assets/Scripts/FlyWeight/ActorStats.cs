using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActorStats", menuName = "Stats/ActorStats", order = 0)]
public class ActorStats : ScriptableObject
{
    [SerializeField] private ActorStatValues _stats;

    public int MaxLife => _stats.MaxLife;
    public float MovementSpeed => _stats.MovementSpeed;


}

[System.Serializable]
public struct ActorStatValues
{
    public int MaxLife;
    public float MovementSpeed;

}
