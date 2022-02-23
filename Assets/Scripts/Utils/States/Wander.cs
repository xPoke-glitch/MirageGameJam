using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Wander : IState
{
    private NavMeshAgent _agent;
    private float _distance;
    private int _layerMask;
    private float _walkSpeed;
    private float _walkAcceleration;

    public Wander(NavMeshAgent agent, float distance, int layer, float walkSpeed, float walkAcceleration)
    {
        _agent = agent;
        _distance = distance;
        _layerMask = layer;
        _walkSpeed = walkSpeed;
        _walkAcceleration = walkAcceleration;
    }

    public void OnEnter()
    {
        _agent.enabled = true;
        _agent.isStopped = false;

        _agent.speed = _walkSpeed;
        _agent.acceleration = _walkAcceleration;

        Vector3 pos = RandomNavSphere(_agent.transform.position, _distance, _layerMask);
        _agent.SetDestination(pos);
    }

    public void OnExit()
    {
        _agent.isStopped = true;
        _agent.enabled = false;
    }

    public void Tick()
    {
        float dist = _agent.remainingDistance;
        if (dist != Mathf.Infinity && _agent.pathStatus == NavMeshPathStatus.PathComplete && dist == 0)
        {
            // Arrived
            Vector3 pos = RandomNavSphere(_agent.transform.position, _distance, _layerMask); // Select the next point
            _agent.SetDestination(pos); // Go to the next point
        }
    }

    private Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }
}
