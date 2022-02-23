using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraEffect : MonoBehaviour
{
    [SerializeField]
    private Volume volume;

    private DepthOfField _dofComponent;
    private float _dofTimer;
    private int _dofValue;

    private void Awake()
    {
        DepthOfField tmp;
        if (volume.profile.TryGet<DepthOfField>(out tmp))
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
        
    }
}
