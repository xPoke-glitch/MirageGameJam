using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flee : IState
{
    private NavMeshAgent _agent;
    private Animal _animal;
    private Vector3 _playerPos;
    private Vector3 _runAwayPoint;

    // [speed: 10, acceleration: 20] Almost uncatchable
    private float _fleeSpeed;
    private float _fleeAcceleration;

    public Flee(NavMeshAgent agent, Animal animal, float fleeSpeed, float fleeAcceleration)
    {
        _agent = agent;
        _animal = animal;
        _fleeSpeed = fleeSpeed;
        _fleeAcceleration = fleeAcceleration;
    }

    public void OnEnter()
    {
        _agent.enabled = true;
        _agent.isStopped = false;
    }

    public void OnExit()
    {
        _agent.isStopped = true;
        _agent.enabled = false;
    }


    public void Tick()
    {
        if (!_animal.GetLastPlayerPositinKnown().Equals(Vector3.zero) && !_agent.hasPath)
        { 
            _playerPos = _animal.GetLastPlayerPositinKnown();
            
            Vector3 dirToPlayer = _agent.transform.position - _playerPos;
            _runAwayPoint = _agent.transform.position + dirToPlayer;

           // Debug.Log("[Flee Tick] RunAwayPoint: " + _runAwayPoint + " - LastPlayerPos: " + _playerPos);

            _agent.acceleration = _fleeAcceleration;
            _agent.speed = _fleeSpeed;
            _agent.SetDestination(_runAwayPoint);
            Debug.Log("[Flee Tick] Destination set");
        }
    }
}
