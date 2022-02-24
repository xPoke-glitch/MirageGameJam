using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class MirageDetector : MonoBehaviour
{
    public float Range;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Mirage mirage = null;
        MirageSpawner spawner = null;
        Collider[] colliders = Physics.OverlapSphere(_player.transform.position, Range);
        foreach (Collider col in colliders)
        {
            if (col.gameObject.TryGetComponent<Mirage>(out mirage))
            {
                mirage.ShowMirage(_player.Water, _player.GetMaxWater());
                mirage.HideMirage(_player.Water, _player.GetMaxWater());
            }
            else if(col.gameObject.TryGetComponent<MirageSpawner>(out spawner))
            {
                spawner.ShowMirage(_player.Water, _player.GetMaxWater());
                spawner.HideMirage(_player.Water, _player.GetMaxWater());
            }
        }
    }
}
