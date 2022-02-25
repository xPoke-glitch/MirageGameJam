using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EquippedWeapon))]
public class EquippedWeaponEditor : Editor
{
    private void OnSceneGUI()
    {
        EquippedWeapon weapon = (EquippedWeapon)target;
        Handles.color = Color.red;
        Handles.DrawWireArc(weapon.transform.position, Vector3.up, Vector3.forward, 360, weapon.AttackRange);
    }
}
