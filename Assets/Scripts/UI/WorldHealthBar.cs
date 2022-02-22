using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHealthBar : BarIndicator
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

    protected override void Update()
    {
        base.Update();
        if(Value == MaxValue)
        {
            fill.enabled = false;
            border.enabled = false;
        }
        else
        {
            fill.enabled = true;
            border.enabled = true;
        }
    }

    public override float Value => character.Health;

    public override float MaxValue => character.MaxHealth;
}
