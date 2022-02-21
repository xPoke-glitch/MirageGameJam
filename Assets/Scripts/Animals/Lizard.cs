using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : Animal
{
    [SerializeField]
    private Transform[] navPoints;

    protected override void SetStateMachine()
    {
        // Implementing the state machine (States and Transitions)

        // States
        var walking = new WalkingAround(_agent, navPoints);

        // Transitions and Any-Transitions
        // ...

        // Set Initial State
        _stateMachine.SetState(walking);
    }
}
