using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BestScore : MonoBehaviour
{
    private TextMeshProUGUI _timerText;
    private void Awake()
    {
        _timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        int seconds = PlayerPrefs.GetInt("timer");
        int bestSeconds = 0;
        bestSeconds = PlayerPrefs.GetInt("best");

        if (seconds > bestSeconds)
        {
            bestSeconds = seconds;
            PlayerPrefs.SetInt("best",bestSeconds);
        }

        _timerText.text = "Best Time:" + '\n';
        _timerText.text = _timerText.text + TimeSpan.FromSeconds(bestSeconds).Hours.ToString("00") + ":"
               + TimeSpan.FromSeconds(bestSeconds).Minutes.ToString("00") + ":" +
               TimeSpan.FromSeconds(bestSeconds).Seconds.ToString("00");
    }
}
