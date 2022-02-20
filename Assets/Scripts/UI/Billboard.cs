using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform _mainCamera;

    private void Awake()
    {
        _mainCamera = FindObjectOfType<Camera>().transform;
    }

    void Update()
    {
        transform.LookAt(transform.position + _mainCamera.forward);
    }
}
