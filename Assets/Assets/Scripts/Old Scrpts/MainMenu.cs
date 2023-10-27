using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject mapSelection;
    public void GoScene()
    {
        menu.SetActive(false);
        mapSelection.SetActive(true);
    }
    public void BackToMenu()
    {
        menu.SetActive(true);
        mapSelection.SetActive(false);
    }

    public void GoSceneOne()
    {
        SceneManager.LoadScene(1);
    }
    public void GoSceneTwo()
    { 
        SceneManager.LoadScene(2);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
