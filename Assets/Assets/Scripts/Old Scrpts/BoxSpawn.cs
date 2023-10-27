using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour
{
    public List<GameObject> box;
    private PlayerOne playerOne;
    private PlayerTwo playerTwo;
    void Start()
    {
        playerOne = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerOne>();
        playerTwo = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwo>();
       
        playerOne.GenerateBox += Active;
        playerTwo.GenerateBox += Active;
    }

    private void Active(object sender, EventArgs e)
    {
        foreach (GameObject item in box)
        {
            item.SetActive(!item.activeSelf);
        }
    }

}