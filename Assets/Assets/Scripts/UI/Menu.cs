using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private KeyCode _pause = KeyCode.Escape;
    [SerializeField] private GameManager _gameManager;
    private int _menuScene;
    private int _jungleLevel;
    private bool _pauseGame;
    private void Start()
    {
        _menuScene = 0;
        _jungleLevel = 1;
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
        Time.timeScale = 0f;
        _pauseGame = true;
        _gameManager._menuGameOver.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        _pauseGame = false;
        _gameManager._menuGameOver.SetActive(false);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _pauseGame = false;
        Time.timeScale = 1f;
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
