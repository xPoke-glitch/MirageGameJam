using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Collider))]
public class Mirage : MonoBehaviour
{  
    [SerializeField]
    private Collider _collider;
    
    private MeshRenderer _meshRenderer;
    private bool _isShowed = false;

    public void ShowMirage()
    {
        if (!_isShowed)
        {
            _isShowed = true;
            _meshRenderer.enabled = true;
            _collider.isTrigger = false;
            FindObjectOfType<CameraBlurEffect>().PlayBlurEffect();
        }
    }

    public void HideMirage()
    {
        if (_isShowed)
        {
            _isShowed = false;
            _meshRenderer.enabled = false;
            _collider.isTrigger = true;
            FindObjectOfType<CameraBlurEffect>().PlayBlurEffect();
        }
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.enabled = false;
    }

    private void Start()
    {
       _collider.isTrigger = true;
    }

}
