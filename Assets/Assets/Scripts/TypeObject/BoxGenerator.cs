using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerator : MonoBehaviour
{

    //#region Private properties
    //private List<Box> currentBox = new List<Box>();
    //[SerializeField] private List<Box> possibleBox;
    //[SerializeField] private List<WayPoint> WayPoints = new List<WayPoint>();
    //[SerializeField] private int BoxToCreate;
    //[SerializeField] private float _timeToCreateBox = 3;
    //#endregion
    //// Start is called before the first frame update
    //void Start()
    //{
    //    for (int i = 0; i < BoxToCreate; i++)
    //    {

    //        Box newBox = nexBox();
    //        for (int j = 0; j < WayPoints.Count; j++)
    //        {
    //            if (WayPoints[j].isUsed == false)
    //            {
    //                newBox.transform.position = WayPoints[j].transform.position;
    //                WayPoints[j].isUsed = true;
    //                break;
    //            }

    //        }
    //        currentBox.Add(newBox);
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    _timeToCreateBox -= Time.deltaTime;
       
    //}
    

    //private void BoxGenerato()
    //{
       
    //}

    //private Box2 nextBox()
    //{
    //    var BoxIndex = Random.Range(0, possibleBox.Count);
    //    Box2 instantiatedBox = Instantiate(possibleBox[BoxIndex]);

    //    return instantiatedBox;
    //}
}
