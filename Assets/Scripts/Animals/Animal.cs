using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Animal : MonoBehaviour
{
    public float Radius;

    [SerializeField]
    protected FoodData foodDrop;

    protected NavMeshAgent _agent;
    protected bool _isPlayerInRange;

    protected StateMachine _stateMachine;

    protected void Awake()
    {
        _isPlayerInRange = false;
        _agent = GetComponent<NavMeshAgent>();
        _stateMachine = new StateMachine();
        SetStateMachine();
    }

    protected void Update()
    {
        _stateMachine.Tick();
    }

    protected virtual void FixedUpdate()
    {
        Player player = null;
        _isPlayerInRange = false;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius);
        foreach(Collider collider in hitColliders)
        {
            if(collider.gameObject.TryGetComponent<Player>(out player))
            {
                _isPlayerInRange = true;
                break;
            }
        }
    }

    protected abstract void SetStateMachine();

    public float GetRadius() => Radius;

}
