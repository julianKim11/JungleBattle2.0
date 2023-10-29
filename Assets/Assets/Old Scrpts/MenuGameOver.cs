using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private PlayerOne playerOne;
    private PlayerTwo playerTwo;

    private void Start()
    {
        playerOne = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerOne>();
        playerTwo = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwo>();
        playerOne.DiePlayer += ActiveMenu;
        playerTwo.DiePlayer += ActiveMenu;
    } 
    private void ActiveMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
    }
    public void Resets()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
     
    public void Exit()
    {
        Application.Quit();
    }
}
