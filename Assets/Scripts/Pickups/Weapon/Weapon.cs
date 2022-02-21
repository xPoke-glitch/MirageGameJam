using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IPickable
{
    [SerializeField] protected WeaponData weapon;
    
    public int animationTime; // think of it later

    private static bool _isPickedUp;
    private Rigidbody _rb;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _rb = null;
        _isPickedUp = false;
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
        print("PICKING UP");

        Transform hand = player.GetComponent<Player>().handToAttachWeapon;

        // Attach to the player's hand
        transform.parent = hand;
        transform.position = hand.position;

        // In order to have physics to drop it
        _rb = gameObject.AddComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    private void Update()
    {
        if (_isPickedUp && Input.GetMouseButtonDown(0))
        {
            print("Playing animation"); // TODO: disable playing animation if it's already playing
            PlayAnimation();
        }
        else if (_isPickedUp && Input.GetMouseButtonDown(1))
        {
            Drop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")) // Could change it later to be based on the layer
        {
            _boxCollider.isTrigger = true;
            Destroy(gameObject.GetComponent<Rigidbody>());
        }
    }

    private void Drop()
    {
        _isPickedUp = false;
        _rb.isKinematic = false;
        //gameObject.GetComponent<Rigidbody>().isKinematic = false;
        _boxCollider.isTrigger = false;

        Player player = gameObject.transform.root.GetComponent<Player>();
        gameObject.transform.position = player.handToAttachWeapon.position + Vector3.forward; // change it later (based on anim)
        gameObject.transform.parent = null;
    }

    private void PlayAnimation()
    {
        // TODO
    }
}
