using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public int Health { get; private set; }

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
        
    }

    void Update()
    {
        
    }
}
