using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class BarIndicator : MonoBehaviour
{ 
    public abstract float Value { get; }
    public abstract float MaxValue { get; }
    protected Slider _slider;

    [SerializeField]
    protected Gradient gradient;
    [SerializeField]
    protected Image fill;
    [SerializeField]
    protected Image border;

    protected virtual void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    void Start()
    {
        _slider.minValue = 0;
        _slider.maxValue = MaxValue;
    }

    protected virtual void Update()
    {
        _slider.value = Value;
        fill.color = gradient.Evaluate(_slider.normalizedValue);
    }
}
