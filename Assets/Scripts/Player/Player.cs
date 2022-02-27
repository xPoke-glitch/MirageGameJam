using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public static event Action OnGameOver;

    public int Health { get; private set; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int Food { get; private set; } 
    public int Water { get; private set; }
    
    [Header("General Stats")]
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int healthRegenAmount;
    [SerializeField]
    private int healthDamageAmount; // when food = 0
    [SerializeField]
    private int maxFood;
    [SerializeField]
    private int maxWater;
    [SerializeField]
    private float foodDecreaseRate; // seconds
    [SerializeField]
    private float waterDecreaseRate; // seconds
    [SerializeField]
    private int healthRegenRate; // seconds
    [SerializeField]
    private int healtDamageRate; // seconds

    private float _foodTimer;
    private float _waterTimer;
    private float _regenTimer;
    private float _damageTimer;


    [SerializeField] PlayerAudioHandler audioRef;



    public void Damage(int amount)
    {
        if (amount <= 0)
            return;
        Health -= amount;
        audioRef.PlayHurtSound();
        if (Health <= 0)
        {
            Health = 0;
            audioRef.PlayDeathSound();
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("DEAD");
        OnGameOver?.Invoke();
    }

    void Start()
    {
        Health = maxHealth;
        Food = maxFood;
        Water = maxWater;
    }

    void Update()
    {
        DecreaseFoodOverTime(foodDecreaseRate);
        DecreaseWaterOverTime(waterDecreaseRate);
        RegenHealth(healthRegenRate);
        DamageHealthOverTime(healtDamageRate);
    }

    private void DecreaseFoodOverTime(float decreaseRate)
    {
        if (Food <= 0)
            return;
        _foodTimer += Time.deltaTime;

        if(_foodTimer >= decreaseRate)
        {
            _foodTimer = 0;
            Food--;
        }
    }

    private void DecreaseWaterOverTime(float decreaseRate)
    {
        if (Water <= 0)
            return;
        _waterTimer += Time.deltaTime;

        if (_waterTimer >= decreaseRate)
        {
            _waterTimer = 0;
            Water--;
        }
    }

    private void RegenHealth(float regenRate)
    {
        if (!(Food == maxFood || Water == maxWater))
            return;
        if (Health <= 0 || Health == MaxHealth)
            return;

        _regenTimer += Time.deltaTime;

        if(_regenTimer >= regenRate)
        {
            _regenTimer = 0;
            Health += healthRegenAmount;
        }
    }

    private void DamageHealthOverTime(float damageRate)
    {
        if (!(Food == 0))
            return;
        if (Health <= 0)
            return;

        _damageTimer += Time.deltaTime;

        if (_damageTimer >= damageRate)
        {
            _damageTimer = 0;
            Damage(healthDamageAmount);
        }
    }

    public void AddFoodAmount(int amount) => Food = Mathf.Clamp(Food + amount, 0, maxFood);

    public void AddWaterAmount(int amount) => Water = Mathf.Clamp(Water + amount, 0, maxWater);

    public int GetMaxFood() => maxFood;
    public int GetMaxWater() => maxWater;
}
