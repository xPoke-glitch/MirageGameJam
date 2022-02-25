using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Animal : MonoBehaviour, IDamageable
{
    [Header("Base Animal")]
    public float Radius;
    public int Health { get; protected set; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField]
    protected int maxHealth;
    [SerializeField]
    protected FoodData foodDrop;
    
    protected bool isAlive = true;

    protected NavMeshAgent _agent;
    protected bool _isPlayerInRange;
    protected Vector3 _lastPlayerPosition;
    protected StateMachine _stateMachine;

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

    protected virtual void FixedUpdate()
    {
        Player player = null;
        _isPlayerInRange = false;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius);
        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent<Player>(out player))
            {
                _isPlayerInRange = true;
                _lastPlayerPosition = player.transform.position;
                break;
            }
        }
        
        if (!_isPlayerInRange)
        {
            _lastPlayerPosition = Vector3.zero;
        }
        
    }

    public float GetRadius() => Radius;

    public Vector3 GetLastPlayerPositinKnown() => _lastPlayerPosition;

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

  /*  protected void OnTriggerEnter(Collider other)
    {
        Weapon weapon;
        if(other.gameObject.TryGetComponent<Weapon>(out weapon))
        {
            Debug.Log("[Animal OnTriggerEnter] "+this.name + " health is "+ Health);
            Damage(weapon.GetDamage());
            weapon.ReduceUsageTime();
        }
    }
  */
    public abstract void Die();
}
