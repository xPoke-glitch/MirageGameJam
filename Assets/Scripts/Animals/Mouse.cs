using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mouse : Animal
{
    [Header("Animal Specific Stats")]
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float walkAcceleration;
    [SerializeField]
    private float fleeSpeed;
    [SerializeField]
    private float fleeAcceleration;
    [SerializeField]
    private Transform[] navPoints;

    public override void Die()
    {
        // Do something
    }

    protected override void SetStateMachine()
    {
        // Implementing the state machine (States and Transitions)

        // States
        var walking = new WalkingAround(_agent, navPoints, walkSpeed, walkAcceleration);
        var flee = new Flee(_agent, this, fleeSpeed, fleeAcceleration);

        // Transitions and Any-Transitions
        _stateMachine.AddTransition(walking, flee, () => _isPlayerInRange);
        _stateMachine.AddTransition(flee, walking, () => { return (_agent.remainingDistance <= 0) && (!_isPlayerInRange); });

        // Set Initial State
        _stateMachine.SetState(walking);
    }
}
