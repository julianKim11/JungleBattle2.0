using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private KeyCode _pause = KeyCode.Escape;
    [SerializeField] private GameManager _gameManager;
    private int _menuScene;
    private bool _pauseGame;
    private void Start()
    {
        _menuScene = 0;
        _pauseGame = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(_pause))
        {
            if (_pauseGame)
                Resume();
            else
                Pause();
        }
    }
    public void Pause()
    {
        GameManager.Instance.PauseGame();
        _pauseGame = true;
        _gameManager._menuGameOver.SetActive(true);
    }
    public void Resume()
    {
        GameManager.Instance.ResumeGame();
        _pauseGame = false;
        _gameManager._menuGameOver.SetActive(false);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _pauseGame = false;
        GameManager.Instance.ResumeGame();
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(_menuScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
