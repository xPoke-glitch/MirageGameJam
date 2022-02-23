using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraZoom : MonoBehaviour
{
    // default zoom: 40
    [SerializeField]
    private float maxZoomFow; // best: 25
    [SerializeField]
    private float minZoomFow; // best: 55
    private CinemachineFreeLook _cinemachine;

    private void Awake()
    {
        _cinemachine = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f) // forward
        {
            _cinemachine.m_CommonLens = true;
            if(Input.GetAxis("Mouse ScrollWheel") >= 0.1f)
            {
                if(_cinemachine.m_Lens.FieldOfView <= minZoomFow)
                    _cinemachine.m_Lens.FieldOfView = minZoomFow;
                else
                    _cinemachine.m_Lens.FieldOfView -= 1;
            }
            else if(Input.GetAxis("Mouse ScrollWheel") <= -0.1f)
            {
                if (_cinemachine.m_Lens.FieldOfView >= maxZoomFow)
                    _cinemachine.m_Lens.FieldOfView = maxZoomFow;
                else
                    _cinemachine.m_Lens.FieldOfView += 1;
            }
        }
    }
}
