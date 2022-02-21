using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingAround : IState
{
    private NavMeshAgent _agent;
    private Transform[] _points;

    public WalkingAround(NavMeshAgent agent, Transform[] points)
    {
        _agent = agent;
        _points = points;
    }

    public void OnEnter()
    {
        _agent.enabled = true;
        _agent.isStopped = false;

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
            _agent.SetDestination(_points[indexPoint].position); // Go to the next point
        }
    }
}
