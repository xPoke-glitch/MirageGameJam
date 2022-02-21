using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/SpawnWeapon", order = 2)]
public class WeaponData : ScriptableObject {
    public string Name;
    public int Damage;
}
