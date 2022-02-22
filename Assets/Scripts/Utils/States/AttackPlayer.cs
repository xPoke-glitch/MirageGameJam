using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackPlayer : IState
{
    private NavMeshAgent _agent;
    private Enemy _enemy;
    public AttackPlayer(NavMeshAgent agent, Enemy enemy)
    {
        _agent = agent;
        _enemy = enemy;
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
        if(_enemy.GetPlayer() != null){
            _enemy.Attack(_enemy.GetPlayer());
        }
        
    }
}
