using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Character PlayerOne;
    public Character PlayerTwo;

    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        PlayerOne.OnDead.AddListener(PlayerOneDead);
        PlayerTwo.OnDead.AddListener(PlayerTwoDead);
    }

    private void PlayerOneDead()
    {
        _gameManager._playerTwoVictory.SetActive(true);
        _gameManager.PauseGame();
    }
    private void PlayerTwoDead()
    {
        _gameManager._playerOneVictory.SetActive(true);
        _gameManager.PauseGame();
    }
}
