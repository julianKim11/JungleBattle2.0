using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _playMenu;
    [SerializeField] private GameObject _mainMenu;
    public void FirstMap()
    {
        SceneManager.LoadScene(1);
    }
    public void SecondMap()
    {
        SceneManager.LoadScene(2);
    }
    public void Play()
    {
        _mainMenu.SetActive(true);
        _playMenu.SetActive(false);
    }
    public void Back()
    {
        _mainMenu.SetActive(false);
        _playMenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
