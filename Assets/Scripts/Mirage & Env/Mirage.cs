using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Collider))]
public class Mirage : MonoBehaviour
{  
    [SerializeField]
    private Collider _collider;
    [SerializeField]
    private int minWaterPercentageTrigger;
    [SerializeField]
    private int maxWaterPercentageTrigger;

    private MeshRenderer _meshRenderer;
    private bool _isShowed = false;
    [SerializeField] bool _areaWithTrees = false;
    private int _minWaterThreshold;
    private int _maxWaterThreshold;

    public void ShowMirage(int currentWater, int maxWater)
    {
        _minWaterThreshold = minWaterPercentageTrigger * maxWater / 100;
        _maxWaterThreshold = maxWaterPercentageTrigger * maxWater / 100;
        if (!_isShowed && (_minWaterThreshold <= currentWater && currentWater <= _maxWaterThreshold))
        {
            _isShowed = true;
            _meshRenderer.enabled = true;
            if (_areaWithTrees)
            {
                foreach (Transform child in transform)
                {
                    child.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            _collider.isTrigger = false;
            FindObjectOfType<CameraBlurEffect>().PlayBlurEffect();
        }
    }

    public void HideMirage(int currentWater, int maxWater)
    {
        _minWaterThreshold = minWaterPercentageTrigger * maxWater / 100;
        _maxWaterThreshold = maxWaterPercentageTrigger * maxWater / 100;
        if (_isShowed && (!(_minWaterThreshold <= currentWater && currentWater <= _maxWaterThreshold)))
        {
            _isShowed = false;
            _meshRenderer.enabled = false;
            if (_areaWithTrees)
            {
                foreach (Transform child in transform)
                {
                    child.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            _collider.isTrigger = true;
            FindObjectOfType<CameraBlurEffect>().PlayBlurEffect();
        }
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.enabled = false;

        if (_areaWithTrees)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void Start()
    {
       _collider.isTrigger = true;
    }

}
