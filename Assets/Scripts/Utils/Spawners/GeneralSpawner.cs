using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSpawner : Spawner
{
    [SerializeField]
    private float spawnRate;

    private float _spawnTimer;

    private void Awake()
    {
        _spawnTimer = 0;
    }

    void Update()
    {
        SpawnOverTime(spawnRate);
    }

    private void SpawnOverTime(float spawnRate)
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= spawnRate)
        {
            _spawnTimer = 0;
            Spawn();
        }
    }
}
