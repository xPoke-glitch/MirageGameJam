using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Icon : MonoBehaviour
{
    private Animator _animator;
    private BarIndicator _barIndicator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _barIndicator = GetComponentInParent<BarIndicator>();
    }

    private void Update()
    {
        if(_barIndicator.Value < (_barIndicator.MaxValue / 2))
        {
            _animator.SetBool("IsWarning", true);
        }
        else
        {
            _animator.SetBool("IsWarning", false);
        }
    }
}
