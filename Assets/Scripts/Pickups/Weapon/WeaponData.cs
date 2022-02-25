using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string Name;
    public int Damage;
    public float AttackRange;
    public float AttackDelay;
    public int MaxDurability;
    public GameObject Model;
    public GameObject PickablePrefab;
}
