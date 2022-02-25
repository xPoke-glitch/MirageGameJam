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

    private bool _canTimer = true;

    private void Awake()
    {
        _timerText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Player.OnGameOver += StopTimer;
    }

    private void OnDisable()
    {
        Player.OnGameOver -= StopTimer;
    }

    void Update()
    {
        if (_canTimer)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1)
            {
                _timer = 0;
                _seconds++;
            }
            _timerText.text = TimeSpan.FromSeconds(_seconds).Hours.ToString("00") + ":"
                + TimeSpan.FromSeconds(_seconds).Minutes.ToString("00") + ":" +
                TimeSpan.FromSeconds(_seconds).Seconds.ToString("00");
        }
    }

    private void StopTimer()
    {
        _canTimer = false;
        SaveTimer();
    }

    private void SaveTimer()
    {
        PlayerPrefs.SetInt("timer", _seconds);
    }
}
