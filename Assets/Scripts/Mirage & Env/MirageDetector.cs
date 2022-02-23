using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class MirageDetector : MonoBehaviour
{
    public float Range;

    [SerializeField]
    private int waterPercentageTrigger;

    private int _waterThreshold;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    void Start()
    {
        _waterThreshold = waterPercentageTrigger * _player.GetMaxWater() / 100;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(_player.Water <= _waterThreshold)
        {
            Mirage mirage = null;
            Collider[] colliders = Physics.OverlapSphere(_player.transform.position, Range);
            foreach (Collider col in colliders)
            {
                if (col.gameObject.TryGetComponent<Mirage>(out mirage))
                {
                    mirage.ShowMirage();
                }
            }
        }
        else if (_player.Water > _waterThreshold)
        {
            Mirage mirage = null;
            Collider[] colliders = Physics.OverlapSphere(_player.transform.position, Range);
            foreach (Collider col in colliders)
            {
                if (col.gameObject.TryGetComponent<Mirage>(out mirage))
                {
                    mirage.HideMirage();
                }
            }
        }
    }
}
