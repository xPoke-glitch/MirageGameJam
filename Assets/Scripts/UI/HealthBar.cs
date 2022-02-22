using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : BarIndicator
{
    [SerializeField]
    private GameObject damageableCharacterObject;

    private IDamageable character;

    protected override void Awake()
    {
        base.Awake();
        character = damageableCharacterObject.GetComponent<IDamageable>();
        if (character == null)
            Debug.LogError("HealthBar Character Object should implement IDamageable!");
    }

    public override float Value => character.Health;

    public override float MaxValue => character.MaxHealth;
}
