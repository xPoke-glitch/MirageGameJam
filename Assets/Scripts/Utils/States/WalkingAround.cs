using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingAround : IState
{
    private NavMeshAgent _agent;
    private Transform[] _points;

    private float _walkSpeed;
    private float _walkAcceleration;

    public WalkingAround(NavMeshAgent agent, Transform[] points, float walkSpeed, float walkAcceleration)
    {
        _agent = agent;
        _points = points;
        _walkSpeed = walkSpeed;
        _walkAcceleration = walkAcceleration;
    }

    public void OnEnter()
    {
        _agent.enabled = true;
        _agent.isStopped = false;

        _agent.speed = _walkSpeed;
        _agent.acceleration = _walkAcceleration;

        int indexPoint = Random.Range(0, _points.Length);
        _agent.SetDestination(_points[indexPoint].position);
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
            int indexPoint = Random.Range(0, _points.Length); // Select the next point
            _agent.speed = _walkSpeed;
            _agent.acceleration = _walkAcceleration;
            _agent.SetDestination(_points[indexPoint].position); // Go to the next point
        }
    }
}
