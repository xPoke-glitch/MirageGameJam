using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Collider))]
public class Mirage : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    [SerializeField]
    private Collider _collider;

    public void ShowMirage()
    {
        _meshRenderer.enabled = true;
        _collider.isTrigger = false;
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
