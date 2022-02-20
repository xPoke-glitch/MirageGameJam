using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IPickable
{
    [SerializeField] public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            PickUp(other.gameObject);
    }

    public void PickUp(GameObject player)
    {
        transform.parent = player.transform;
        transform.position = player.GetComponent<Player>().handToAttachWeapon.position;
    }
}
