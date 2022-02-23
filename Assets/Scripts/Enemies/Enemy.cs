using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour, IDamageable
{
    [Header("Base Enemy")]
    public float SightRadius;
    public float TriggerRadius;
    public float AttackRadius;

    public int Health { get; protected set; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField]
    protected int maxHealth;
    [SerializeField]
    protected int damagePotency;
    [SerializeField]
    protected float attackDelay;

    protected bool isAlive = true;
    protected bool _isPlayerInSightRange;
    protected bool _isPlayerInTriggerRange;
    protected bool _isPlayerInAttackRange;

    protected NavMeshAgent _agent;
    protected Vector3 _lastPlayerPosition;
    protected StateMachine _stateMachine;
    protected Player _player = null;

    public abstract void Die();
    protected abstract void SetStateMachine();

    private bool _canAttack = true;

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
    
    public Vector3 GetLastPlayerPositinKnown() => _lastPlayerPosition;
    public Player GetPlayer() => _player;

    public void Attack(IDamageable target)
    {
        if (_canAttack)
            StartCoroutine(DamageWithDelay(attackDelay,target));
    }

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
        if (!(AttackRadius < TriggerRadius && TriggerRadius < SightRadius))
            Debug.LogError("Enemy radius must follow this rule: AttackRadius < TriggerRadius < SightRadius -- Please Check Radius Proprieties");

        _lastPlayerPosition = Vector3.zero;

        _isPlayerInSightRange = false;
        _isPlayerInTriggerRange = false;
        _isPlayerInAttackRange = false;

        Health = maxHealth;
    }

    protected void Update()
    {
        _stateMachine.Tick();
        Debug.Log("[Enemy Update] Player Ranges: Attack Range -> " + _isPlayerInAttackRange +
                                                 " Trigger Range -> "+_isPlayerInTriggerRange+
                                                 " Sight Range -> "+_isPlayerInSightRange);
    }

    protected virtual void FixedUpdate()
    {
        Collider[] hitColliders = null;

        _isPlayerInSightRange = false;
        _isPlayerInTriggerRange = false;
        _isPlayerInAttackRange = false;

        hitColliders = Physics.OverlapSphere(transform.position, AttackRadius);
        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent<Player>(out _player))
            {
                _isPlayerInAttackRange = true;
                _isPlayerInTriggerRange = true;
                _isPlayerInSightRange = true;
                _lastPlayerPosition = _player.transform.position;
                break;
            }
        }

        if (!_isPlayerInAttackRange)
        {
            hitColliders = Physics.OverlapSphere(transform.position, TriggerRadius);
            foreach (Collider collider in hitColliders)
            {
                if (collider.gameObject.TryGetComponent<Player>(out _player))
                {
                    _isPlayerInTriggerRange = true;
                    _isPlayerInSightRange = true;
                    _lastPlayerPosition = _player.transform.position;
                    break;
                }
            }
        }

        if (!_isPlayerInTriggerRange)
        {
            hitColliders = Physics.OverlapSphere(transform.position, SightRadius);
            foreach (Collider collider in hitColliders)
            {
                if (collider.gameObject.TryGetComponent<Player>(out _player))
                {
                    _isPlayerInSightRange = true;
                    _lastPlayerPosition = _player.transform.position;
                    break;
                }
            }
        }

        if (!_isPlayerInSightRange && !_isPlayerInTriggerRange && !_isPlayerInAttackRange)
        {
            _lastPlayerPosition = Vector3.zero;
            _player = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Weapon weapon;
        if (other.gameObject.TryGetComponent<Weapon>(out weapon))
        {
            Debug.Log("[Enemy OnTriggerEnter] " + this.name + " health is " + Health);
            Damage(weapon.GetDamage());
            weapon.ReduceUsageTime();
        }
    }

    private IEnumerator DamageWithDelay(float delay, IDamageable target)
    {
        _canAttack = false;
        target.Damage(damagePotency);
        Debug.Log("[Enemy DamageWithDelay] ATTACK DONE");
        yield return new WaitForSeconds(delay);
        _canAttack = true;
    }

}
