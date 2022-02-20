using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class BarIndicator : MonoBehaviour
{ 
    protected abstract float Value { get; }
    protected abstract float MaxValue { get; }
    protected Slider _slider;

    protected virtual void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    void Start()
    {
        _slider.minValue = 0;
        _slider.maxValue = MaxValue;
    }

    void Update()
    {
        _slider.value = Value;
    }
}
