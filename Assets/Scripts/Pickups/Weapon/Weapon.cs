using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IPickable
{
    [SerializeField] protected WeaponData weaponData;
    
    public int animationTime; // think of it later

    public static bool IsPickedUp { get => _isPickedUp; }

    public static Weapon CurrentWeapon;

    private int _usageTime;
    private static bool _isPickedUp;
    private Rigidbody _rb;
    private BoxCollider _boxCollider;
    private bool _firstTimeUsage;
    private bool _canBeUsed;
    
    
    private void Awake()
    {
        _rb = null;
        _isPickedUp = false;
        CurrentWeapon = null;
        _usageTime = 0;
        _firstTimeUsage = false;
        _canBeUsed = true;
        TryGetComponent<BoxCollider>(out _boxCollider);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!_isPickedUp && other.gameObject.CompareTag("Player"))
        {
            PickUp(other.gameObject);
            _isPickedUp = true;
        }
    }

    public void PickUp(GameObject player)
    {
        CurrentWeapon = this;
        if (!_firstTimeUsage) // if never picked up
        {
            _firstTimeUsage = true;
            _usageTime = CurrentWeapon.weaponData.MaxUsageTime;
        }


        Transform hand = player.GetComponent<Player>().handToAttachWeapon;

        // Attach to the player's hand
        transform.parent = hand;
        transform.position = hand.position;

        // In order to have physics to drop it
        _rb = gameObject.AddComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    public int GetDamage()
    {
        return CurrentWeapon == null ? 0 : CurrentWeapon.weaponData.Damage;
    }

    public void ReduceUsageTime()
    {
        if (!CurrentWeapon) return;
        _usageTime--;
        print("USAGE TIME is " + _usageTime);
        if(_usageTime <= 0)
        {
            _canBeUsed = false;
            Drop();
            Destroy(this.gameObject, 1f);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")) // Could change it later to be based on the layer
        {
            // if it can't be used anymore (usage time <= 0), remove collisions so that it will go through the ground
            _boxCollider.isTrigger = !_canBeUsed;
            //Destroy(gameObject.GetComponent<Rigidbody>());
        }
    }

    public void Drop()
    {
        _isPickedUp = false;
        _rb.isKinematic = false;

        _boxCollider.isTrigger = false;
        CurrentWeapon = null;

        Player player = gameObject.transform.root.GetComponent<Player>();
        gameObject.transform.position = player.handToAttachWeapon.position + Vector3.forward; // change it later (based on anim)
        gameObject.transform.parent = null;
    }

    /// <summary>
    /// Player attacks an animal
    /// </summary>
    public void PlayAttackAnimation() 
    {
        // Call play animation method, argument is weaponData.AnimationClip
        print("Animation");
    }
}
