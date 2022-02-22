using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : IState
{
    private NavMeshAgent _agent;
    private Enemy _enemy;
    private float _followSpeed;
    private float _followAcceleration;

    public FollowPlayer(NavMeshAgent agent, Enemy enemy, float followSpeed, float followAcceleration)
    {
        _agent = agent;
        _enemy = enemy;
        _followSpeed = followSpeed;
        _followAcceleration = followAcceleration;
    }

    public void OnEnter()
    {
        _agent.enabled = true;
        _agent.isStopped = false;

        _agent.speed = _followSpeed;
        _agent.acceleration = _followAcceleration;
    }

    public void OnExit()
    {
        _agent.isStopped = true;
        _agent.enabled = false;
    }

    public void Tick()
    {
        _agent.SetDestination(_enemy.GetLastPlayerPositinKnown());
    }
}
