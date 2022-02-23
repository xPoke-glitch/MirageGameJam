using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
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
    private int maxFood;
    [SerializeField]
    private int maxWater;
    [SerializeField]
    private float foodDecreaseRate; // seconds
    [SerializeField]
    private float waterDecreaseRate; // seconds
    [SerializeField]
    private int healthRegenRate; // seconds

    [Header("References")]
    [SerializeField]
    public Transform handToAttachWeapon; 

    private float _foodTimer;
    private float _waterTimer;
    private float _regenTimer;

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
    public void Die()
    {
        // Do something when the player Dies
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

    public void AddFoodAmount(int amount) => Food = Mathf.Clamp(Food + amount, 0, maxFood);

    public void AddWaterAmount(int amount) => Water = Mathf.Clamp(Water + amount, 0, maxWater);

    public int GetMaxFood() => maxFood;
    public int GetMaxWater() => maxWater;
}
