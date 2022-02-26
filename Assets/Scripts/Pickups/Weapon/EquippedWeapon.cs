using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedWeapon : MonoBehaviour
{
    public bool IsEquipped { get; private set; }
    public bool IsAttacking { get; private set; }
    public float AttackRange;

    [SerializeField] private WeaponData weaponData;
    [SerializeField] private Transform weaponModelTransformParent;

    private GameObject _model;
    private bool _canAttack = true;

    private int _durability;

    public void EquipWeapon(WeaponData data, int durability)
    {
        if (!IsEquipped)
        {
            weaponData = data;

            if (_model != null)
            {
                Destroy(_model);
            }

            if (weaponData.Model != null)
            {
                _model = Instantiate(weaponData.Model);
                _model.transform.SetParent(weaponModelTransformParent, false);
                _model.transform.Rotate(new Vector3(0.0f, 0.0f, 0.0f));
                _durability = durability;
                _canAttack = true;
            }
            IsEquipped = true;
        }
    }

    public void Attack(IDamageable target)
    {
        target.Damage(weaponData.Damage);
    }

    public void Drop()
    {
        if (IsEquipped)
        {
            GameObject droppedObject = Instantiate(weaponData.PickablePrefab);
            droppedObject.transform.position = this.gameObject.transform.position+Vector3.forward;
            droppedObject.transform.SetParent(null);
            droppedObject.GetComponentInChildren<Weapon>().CurrentDurability = _durability;
           
            Destroy(_model);
            _model = null;
            weaponData = null;

            IsEquipped = false;
        }
    }

    private void Awake()
    {
        IsEquipped = false;
        
    }

    // FOR NOW -- THERE WILL BE ANOTHER SCRIPT
    private void Update()
    {
        if (IsEquipped)
        {
            AttackRange = weaponData.AttackRange;
        }
        else
        {
            AttackRange = 0;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Drop();
        }

        if (_durability <= 0)
        {
            Destroy(_model);
            StopAllCoroutines();
            _model = null;
            weaponData = null;

            IsEquipped = false;
        }

        Debug.Log(_durability+" "+_canAttack);

    }

    private void FixedUpdate()
    {
        IsAttacking = false;
        if(IsEquipped && Input.GetKeyDown(KeyCode.Mouse0) && _canAttack)
        {
            IsAttacking = true;
            _canAttack = false;
            _durability--;

            if (_durability <= 0)
                return;

            IDamageable target = null;
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, AttackRange);
            foreach(Collider col in hitColliders)
            {
                if(col.gameObject.TryGetComponent(out target))
                {
                    if (!this.gameObject.GetComponent<IDamageable>().Equals(target))
                    {
                        target.Damage(weaponData.Damage);
                    }
                }
            }
            StartCoroutine(COWaitForNextAttack(weaponData.AttackDelay));
        }
    }

    private IEnumerator COWaitForNextAttack(float delay)
    {
        yield return new WaitForSeconds(delay);
        _canAttack = true;
    }

}
