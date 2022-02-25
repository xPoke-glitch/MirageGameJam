using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimeScore : MonoBehaviour
{
    private TextMeshProUGUI _timerText;

    private void Awake()
    {
        _timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        int seconds = PlayerPrefs.GetInt("timer");
        _timerText.text = "Time Survived:" + '\n';
        _timerText.text = _timerText.text + TimeSpan.FromSeconds(seconds).Hours.ToString("00") + ":"
               + TimeSpan.FromSeconds(seconds).Minutes.ToString("00") + ":" +
               TimeSpan.FromSeconds(seconds).Seconds.ToString("00");
    }
}
