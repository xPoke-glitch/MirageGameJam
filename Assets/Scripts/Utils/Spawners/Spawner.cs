using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Spawner : MonoBehaviour
{
    [Header("Base Spawner")]
    public float Range;

    [SerializeField]
    protected GameObject[] prefabs;

    public void Spawn() // 1 object
    {
        // Choose random prefab
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject prefab = prefabs[randomIndex];

        Vector3 spawnPos = RandomPointInRange(this.transform.position, Range);

        if (spawnPos.x == Mathf.Infinity && spawnPos.y == Mathf.Infinity && spawnPos.z == Mathf.Infinity)
            return;
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

    protected Vector3 RandomPointInRange(Vector3 origin, float distance, int layermask = -1)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }
}
