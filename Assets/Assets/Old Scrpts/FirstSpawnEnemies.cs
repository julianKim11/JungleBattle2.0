using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSpawnEnemies : MonoBehaviour
{
    public List<GameObject> enemies;
    private PlayerOne playerOne;
    private PlayerTwo playerTwo;
    private GameManager timer;
    void Start()
    {
        playerOne = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerOne>();
        playerTwo = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwo>();
        timer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        timer.GenerateEnemies += Active;
        playerOne.GenerateEnemies += Active;
        playerTwo.GenerateEnemies += Active;
    }

    private void Active(object sender, EventArgs e)
    {
        foreach(GameObject item in enemies)
        {
            item.SetActive(!item.activeSelf);
        }
    }

}
