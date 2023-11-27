using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeController : MonoBehaviour
{
    public int min, seg;
    public float _left;
    public bool _onGoing;

    [SerializeField] private TMP_Text _time;
    [SerializeField] private GameManager _gameManager;
    public void Start()
    {
        _left = (min * 60) + seg;
        _onGoing = true;
    }
    public void Update()
    {
        if (_onGoing)
        {
            _left -= Time.deltaTime;
            if (_left < 1)
            {
                Debug.Log("Empate");
                _onGoing = false;
                _gameManager._tie.SetActive(true);
                _gameManager.PauseGame();
            }
            int tempMin = Mathf.FloorToInt(_left / 60);
            int tempSeg = Mathf.FloorToInt(_left % 60);
            _time.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }
    }
}