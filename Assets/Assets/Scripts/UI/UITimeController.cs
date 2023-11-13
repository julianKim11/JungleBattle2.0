using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimeController : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] private TMP_Text _time;
    private float _left;
    private bool _onGoing;

    private void Awake()
    {
        _left = (min * 60) + seg;
        _onGoing = true;
    }
    private void Update()
    {
        if(_onGoing)
        {
            _left -= Time.deltaTime;
            if (_left < 1)
            {
                Debug.Log("Empate");
                _onGoing = false;
            }
            int tempMin = Mathf.FloorToInt(_left / 60);
            int tempSeg = Mathf.FloorToInt(_left % 60);
            _time.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }
    }
}
