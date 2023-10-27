using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private GameObject tie;
    public event EventHandler GenerateEnemies;

    public List<GameObject> box;
    public List<GameObject> box1;
    public List<GameObject> box2;

    public List<GameObject> Enemy1;
    public List<GameObject> Enemy2;
    public List<GameObject> Enemy3;

    public List<GameObject> Banana1;
    public List<GameObject> Banana2;
    public List<GameObject> Banana3;
    public List<GameObject> Watermelon;

    public List<GameObject> bird;

    public static GameManager Instance;
    [SerializeField] public int enemyCountSpawn = 0;
    [SerializeField] public float activara1 = 0;
    [SerializeField] public float activara2 = 0;

    [SerializeField] public float activarb1 = 0;
    [SerializeField] public float activarb2 = 0;
    [SerializeField] public float activarb3 = 0;

    [SerializeField] public float activarc1 = 0;
    [SerializeField] public float activarc2 = 0;
    [SerializeField] public float activarc3 = 0;

    [SerializeField] public float activard1 = 0;
    [SerializeField] public float activard2 = 0;

    [SerializeField] public float activarB = 0;
    [SerializeField] public float activeWatermelon = 0;

    [Header("Timer")]
    [SerializeField] private float tiempoMaximo;
    [SerializeField] private Slider slider;
    private float tiempoActual;
    private bool tiempoActivo = false;

    [Header("Dead Player")]
    public int p1 = 0;
    public int p2 = 0;
    public int pause = 1;
    public bool pauseState = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
    private void Start()
    {
        ActivarTemporizador();
    }
    private void Update()
    {
        if (tiempoActivo)
        {
            CambiarContador();
            if(p1 == 1)
            {
                DesactivarTemporizador();
            }
        }
        Active();
        StateMenu();
        MenuInGame();
    }

    private void StateMenu()
    {
        if(Input.GetButtonUp("Cancel"))
        {
            MasUno();
        }
    }
    private void MasUno()
    {
        pause += 1;
    }
    public void MenuInGame()
    {
        if(pause % 2 == 0)
        {
            menuGameOver.SetActive(true);
            pauseState = true;
            DesactivarTemporizador();
        }
        else
        {
            menuGameOver.SetActive(false);
            pauseState = false;
            CambiarTemporizador(true);
        }
    }
    private void CambiarContador()
    {
        tiempoActual -= Time.deltaTime;

        if(tiempoActual >= 0)
        {
            slider.value = tiempoActual;
        }

        if(tiempoActual < 7.0)
        {
            activara1++;
        }
        if (tiempoActual < 4.0)
        {
            activara2++;
        }

        EnemySpawn();
        BananaSpawn();
        BoxSpawn();
        BirdSpawn();

        if (tiempoActual <= 0)
        {
            pause = 0;
            tiempoActivo = false;
            menuGameOver.SetActive(true);
            tie.SetActive(true);
            p1++;
            p2++;
        }
    }

    private void CambiarTemporizador(bool estado)
    {
        tiempoActivo = estado;
    }

    public void ActivarTemporizador()
    {
        tiempoActual = tiempoMaximo;
        slider.maxValue = tiempoMaximo;
        CambiarTemporizador(true);
    }

    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }

    public void EnemySpawn()
    {
        if (tiempoActual < 55)
        {
            activarb1++;
        }
        if (tiempoActual < 35)
        {
            activarb2++;
            activara2++;
        }
        if (tiempoActual < 25)
        {
            activarb3++;
        }
    }
    public void BananaSpawn()
    {
        if (tiempoActual < 45)
        {
            activarc1++;
            activara1++;
        }
        if (tiempoActual < 30)
        {
            activarc2++;
        }
        if (tiempoActual < 20)
        {
            activarc3++;
        }
    }

    public void BoxSpawn()
    {
        if (tiempoActual < 50)
        {
            activard1++;
        }
        if (tiempoActual < 30)
        {
            activard2++;
        }
    }

    public void BirdSpawn()
    {
        if (tiempoActual < 20)
        {
            activarB++;
        }
    }

    public void Active()
    {
        if(activarB == 1)
        {
            foreach (GameObject item in bird)
            {
                item.SetActive(!item.activeSelf);
            }
        }
        if (activara1 == 1)
        {
            GenerateEnemies?.Invoke(this, EventArgs.Empty);
        }
        else if (activara2 == 1)
        {
            foreach (GameObject item in box)
            {
                item.SetActive(!item.activeSelf);
            }
        }

        if (activarb1 == 1)
        {
            foreach (GameObject item in Enemy1)
            {
                item.SetActive(!item.activeSelf);
            }
        }
        if (activarb2 == 1)
        {
            foreach (GameObject item in Enemy2)
            {
                item.SetActive(!item.activeSelf);
            }
        }
        if (activarb3 == 1)
        {
            
            foreach (GameObject item in Enemy2)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Enemy3)
            {
                item.SetActive(!item.activeSelf);
            }
            foreach (GameObject item in Watermelon)
            {
                item.SetActive(!item.activeSelf);
            }
        }

        if (activarc1 == 1)
        {
            foreach (GameObject item in Banana1)
            {
                item.SetActive(!item.activeSelf);
            }
        }
        if (activarc2 == 1)
        {
            foreach (GameObject item in Banana2)
            {
                item.SetActive(!item.activeSelf);
            }
        }
        if (activarc3 == 1)
        {
            foreach (GameObject item in Banana3)
            {
                item.SetActive(!item.activeSelf);
            }
        }

        if (activard1 == 1)
        {
            foreach (GameObject item in box1)
            {
                item.SetActive(!item.activeSelf);
            }
        }
        if (activard2 == 1)
        {
            foreach (GameObject item in Enemy1)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in box2)
            {
                item.SetActive(!item.activeSelf);
            }
        }
    }
}
