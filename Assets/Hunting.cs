using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunting : MonoBehaviour
{
    private void Update()
    {
        if (Weapon.IsPickedUp && Input.GetMouseButtonDown(0))
        {
            Weapon.CurrentWeapon.PlayAttackAnimation();
        }
        else if (Weapon.IsPickedUp && Input.GetMouseButtonDown(1))
        {
            Weapon.CurrentWeapon.Drop();
        }
    }
}
