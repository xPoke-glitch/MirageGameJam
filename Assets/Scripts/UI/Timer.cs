using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Timer : MonoBehaviour
{
    private float _timer;
    private int _seconds;
    private TextMeshProUGUI _timerText;

    private void Awake()
    {
        _timerText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= 1)
        {
            _timer = 0;
            _seconds++;
        }
        _timerText.text = TimeSpan.FromSeconds(_seconds).Hours.ToString("00") + ":"
            + TimeSpan.FromSeconds(_seconds).Minutes.ToString("00") + ":" +
            TimeSpan.FromSeconds(_seconds).Seconds.ToString("00");
    }
}
