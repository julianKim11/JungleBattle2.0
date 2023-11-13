using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    #region Private properties
    private List<Enemies> currentEnemie = new List<Enemies>();
    [SerializeField] private List<Enemies> possibleEnemy;
    [SerializeField] private List<WayPoint> WayPoints = new List<WayPoint>();
    [SerializeField] private int EnemyToCreate;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < EnemyToCreate; i++)
        {
         
            Enemies newEnemy = CreateEnemy();
            for (int j = 0; j < WayPoints.Count; j++)
            {
                if (WayPoints[j].isUsed == false)
                {
                    newEnemy.transform.position = WayPoints[j].transform.position;
                    WayPoints[j].isUsed = true;
                }
                else 
                {
                    return;
                }
            }
            currentEnemie.Add(newEnemy);
        }
    }

    private Enemies CreateEnemy()
    {
        var EnemyIndex = Random.Range(0, possibleEnemy.Count); //crea un Enemy State de los que se encuentren en la lista
        Enemies instantiatedMonster = Instantiate(possibleEnemy[EnemyIndex]);   

        return instantiatedMonster;
    }
}
