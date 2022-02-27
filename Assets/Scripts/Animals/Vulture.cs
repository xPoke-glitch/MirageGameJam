using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Vulture : Animal
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

    [Header("Navigation AI")]
    [SerializeField]
    private float walkRange;
    [SerializeField]
    private int layerMask;

    AudioSource audioRef;

    protected override void Start()
    {
        base.Start();
        audioRef = GetComponent<AudioSource>();
        InvokeRepeating("AnimalAudio", 3, Random.Range(3, 20));
    }
    public override void Die()
    {
        if (!isAlive) return;
        isAlive = false;
        GameObject meat = Instantiate(foodDrop.Prefab, transform.position + Vector3.up, transform.rotation);
        meat.GetComponent<Rigidbody>().AddForce(10 * Vector3.up, ForceMode.Impulse);
        audioRef.Play();
        Destroy(this.gameObject);
    }

    void AnimalAudio()
    {
        audioRef.Play();
    }
    protected override void SetStateMachine()
    {
        // Implementing the state machine (States and Transitions)

        // States
        var walking = new Wander(_agent, walkRange, layerMask, walkSpeed, walkAcceleration);
        var flee = new Flee(_agent, this, fleeSpeed, fleeAcceleration);

        // Transitions and Any-Transitions
        _stateMachine.AddTransition(walking, flee, () => _isPlayerInRange);
        _stateMachine.AddTransition(flee, walking, () => { return (_agent.remainingDistance <= 0) && (!_isPlayerInRange); });

        // Set Initial State
        _stateMachine.SetState(walking);
    }
}
