using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [Header("Base Enemy")]
    public float EnemyTriggerRadius;
    public float EnemyFleeRadius;

    public int Health { get; protected set; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField]
    protected int maxHealth;

    protected NavMeshAgent _agent;
    protected bool _isPlayerInRange;
    protected Vector3 _lastPlayerPosition;
    protected StateMachine _stateMachine;

    public void Damage(int amount)
    {
        if (amount <= 0)
            return;
        Health -= amount;
        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
    }  
    public abstract void Die();
    public Vector3 GetLastPlayerPositinKnown() => _lastPlayerPosition;

    protected abstract void SetStateMachine();

    protected void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        // Randomize the collision avoidance priority
        int collsionPrio = Random.Range(0, 51);
        _agent.avoidancePriority = collsionPrio;

        _stateMachine = new StateMachine();
        SetStateMachine();
    }

    protected void Start()
    {
        _lastPlayerPosition = Vector3.zero;
        _isPlayerInRange = false;
        Health = maxHealth;
    }

    protected void Update()
    {
        _stateMachine.Tick();
    }
}
