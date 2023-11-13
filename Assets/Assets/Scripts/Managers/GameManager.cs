using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject _menuGameOver;
    [SerializeField] public GameObject _tie;
    [SerializeField] public GameObject _playerOneVictory;
    [SerializeField] public GameObject _playerTwoVictory;

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
