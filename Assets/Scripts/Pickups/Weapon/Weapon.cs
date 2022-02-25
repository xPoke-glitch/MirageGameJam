using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Weapon : MonoBehaviour
{
    public int CurrentDurability {get; set;}
    [SerializeField] private WeaponData weaponData;

    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        StartCoroutine(CODelayTriggerActivation(1.0f));
        CurrentDurability = weaponData.MaxDurability;
    }

    private void OnTriggerEnter(Collider other)
    {
        EquippedWeapon weapon = null;
        if (other.gameObject.TryGetComponent(out weapon))
        {
            if (!weapon.IsEquipped)
            {
                weapon.EquipWeapon(weaponData, CurrentDurability);
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }

    public void SetWeaponData(WeaponData data)
    {
        weaponData = data;
    }

    private IEnumerator CODelayTriggerActivation(float delay)
    {
        _collider.enabled = false;
        yield return new WaitForSeconds(delay);
        _collider.enabled = true;
    }
}
