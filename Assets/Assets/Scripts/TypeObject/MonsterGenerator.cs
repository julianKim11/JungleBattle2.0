using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    #region Private properties
    private List<GameObject> currentEnemies = new List<GameObject>();
    [SerializeField] private List<GameObject> possibleEnemy;
    [SerializeField] private List<WayPoint> WayPoints = new List<WayPoint>();
    [SerializeField] private int EnemyToCreate;
    #endregion
    void Start()
    {
        for (int i = 0; i < EnemyToCreate; i++)
        {
            GameObject newEnemy = CreateEnemy();
            for (int j = 0; j < WayPoints.Count; j++)
            {
                if (WayPoints[j].isUsed == false)
                {
                    newEnemy.transform.position = WayPoints[j].transform.position;
                    WayPoints[j].isUsed = true;
                    break;
                } 
            }
            currentEnemies.Add(newEnemy);
        }
    }

    private GameObject CreateEnemy()
    {
        var EnemyIndex = Random.Range(0, possibleEnemy.Count); //crea un Enemy State de los que se encuentren en la lista
        GameObject instantiatedMonster = Instantiate(possibleEnemy[EnemyIndex]);   

        return instantiatedMonster;
    }
}