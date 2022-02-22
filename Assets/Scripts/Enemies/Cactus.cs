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
        
        // Transitions and Any-Transitions
        
        // Set Initial State
        _stateMachine.SetState(walking);
    }


}
