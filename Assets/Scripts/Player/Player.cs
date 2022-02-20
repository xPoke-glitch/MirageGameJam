using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public int Health { get; private set; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int Food { get; private set; } // int?
    public int Water { get; private set; } // int?
    
    [Header("General Stats")]
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int maxFood;
    [SerializeField]
    private int maxWater;
    [SerializeField]
    private float foodDecreaseRate; // seconds
    [SerializeField]
    private float waterDecreaseRate; // seconds

    [Header("References")]
    [SerializeField]
    public Transform handToAttachWeapon; 

    private float _foodTimer;
    private float _waterTimer;

    public void Damage(int amount)
    {
        if (amount <= 0)
            return;
        Health -= amount;
        if (Health <= 0)
            Health = 0;
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
        //Debug.Log("[Player Update] Current Food: "+Food);
        //Debug.Log("[Player Update] Current Water "+Water);
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

    public void AddFoodAmount(int amount) =>  Food += amount;

    public void AddWaterAmount(int amount) => Water += amount;

    public int GetMaxFood() => maxFood;
    public int GetMaxWater() => maxWater;
}
