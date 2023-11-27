using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    #region Private properties
    private List<Item> currentItem = new List<Item>();
    [SerializeField] private List<Item> possibleItem;
    [SerializeField] private List<WayPoint> WayPoints = new List<WayPoint>();
    [SerializeField] private int ItemToCreate;
    #endregion
    void Start()
    {
        for (int i = 0; i < ItemToCreate; i++)
        {

            Item newItem = nexItem();
            for (int j = 0; j < WayPoints.Count; j++)
            {
                if (WayPoints[j].isUsed == false)
                {
                    newItem.transform.position = WayPoints[j].transform.position;
                    WayPoints[j].isUsed = true;
                    break;
                }

            }
            currentItem.Add(newItem);
        }
    }

    private Item nexItem()
    {
        if (possibleItem.Count == 0)
        {
            // No items left in the list
            return null;
        }
        var ItemIndex = Random.Range(0, possibleItem.Count);
        
        Item instantiatedItem = Instantiate(possibleItem[ItemIndex]);
        possibleItem.RemoveAt(ItemIndex);
        return instantiatedItem;
    }
}