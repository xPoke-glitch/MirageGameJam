using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : Enemy
{
    [Header("Enemy Specific Stats")]
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float walkAcceleration;
    [SerializeField]
    private float followSpeed;
    [SerializeField]
    private float followAcceleration;
    [SerializeField]
    private Transform[] navPoints;

    public override void Die()
    {
        // TO-DO
    }

    protected override void SetStateMachine()
    {
        // Implementing the state machine (States and Transitions)

        // States
        var walking = new WalkingAround(_agent, navPoints, walkSpeed, walkAcceleration);
        var following = new FollowPlayer(_agent, this, followSpeed, followAcceleration);
        var attack = new AttackPlayer(_agent, this);

        // Transitions and Any-Transitions
        _stateMachine.AddTransition(walking, following, () => _isPlayerInTriggerRange);
        _stateMachine.AddTransition(following, walking, () => !_isPlayerInSightRange);
        _stateMachine.AddTransition(following, attack, () => _isPlayerInAttackRange);
        _stateMachine.AddTransition(attack, following, () => !_isPlayerInAttackRange && _isPlayerInSightRange);
        
        // Set Initial State
        _stateMachine.SetState(walking);
    }


}
