using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirageSpawner : Spawner
{
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private int minWaterPercentageTrigger;
    [SerializeField]
    private int maxWaterPercentageTrigger;

    private int _minWaterThreshold;
    private int _maxWaterThreshold;
    private float _spawnTimer;
    private bool _canSpawn = false;

    public void ShowMirage(int currentWater, int maxWater)
    {
        _minWaterThreshold = minWaterPercentageTrigger * maxWater / 100;
        _maxWaterThreshold = maxWaterPercentageTrigger * maxWater / 100;
        if((_minWaterThreshold <= currentWater && currentWater <= _maxWaterThreshold))
            _canSpawn = true;
    }

    public void HideMirage(int currentWater, int maxWater)
    {
        _minWaterThreshold = minWaterPercentageTrigger * maxWater / 100;
        _maxWaterThreshold = maxWaterPercentageTrigger * maxWater / 100;
        if (!(_minWaterThreshold <= currentWater && currentWater <= _maxWaterThreshold))
        {
            _canSpawn = false;
            _spawnTimer = 0;
        }
    }

    private void Awake()
    {
        _spawnTimer = 0;
    }

    void Update()
    {
        if(_canSpawn)
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
