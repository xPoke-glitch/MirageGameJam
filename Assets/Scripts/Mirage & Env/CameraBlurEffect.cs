using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Volume))]
public class CameraBlurEffect : MonoBehaviour
{
    [SerializeField]
    private float increaseRate;
    [SerializeField]
    private float decreaseRate;

    private Volume _volume;

    private DepthOfField _dofComponent;
    private float _dofTimer;
    private bool _shouldDecrease = false;
    private bool _shouldPlayBlurAnimation = false;
    private bool _isBlurPlaying = false;

    private void Awake()
    {
        _volume = GetComponent<Volume>();
        DepthOfField tmp;
        if (_volume.profile.TryGet<DepthOfField>(out tmp))
        {
            _dofComponent = tmp;
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_shouldPlayBlurAnimation)
        {
            _isBlurPlaying = true;
            if (_dofComponent.focalLength.value < 36 && !_shouldDecrease)
            {
                IncreaseFocalLenght(increaseRate);
            }
            if (_dofComponent.focalLength.value == 36)
            {
                _shouldDecrease = true;
            }
            if (_shouldDecrease)
            {
                DecreaseFocalLenght(decreaseRate);
                if (_dofComponent.focalLength.value == 18)
                {
                    _shouldDecrease = false;
                    _shouldPlayBlurAnimation = false;
                    _isBlurPlaying = false;
                }
            }
        }
    }
    public void PlayBlurEffect()
    {
        if (!_isBlurPlaying)
        {
            _shouldPlayBlurAnimation = true;
        }   
    }

    private void IncreaseFocalLenght(float increaseRate)
    {
        _dofTimer += Time.deltaTime;

        if(_dofTimer >= increaseRate)
        {
            _dofTimer = 0;
            _dofComponent.focalLength.value++;
        }
    }
    private void DecreaseFocalLenght(float decreaseRate)
    {
        _dofTimer += Time.deltaTime;

        if (_dofTimer >= decreaseRate)
        {
            _dofTimer = 0;
            _dofComponent.focalLength.value--;
        }
    }
}
