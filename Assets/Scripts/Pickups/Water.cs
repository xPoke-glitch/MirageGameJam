using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour, IPickable
{
    [SerializeField] int amount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            PickUp(other.gameObject);
    }

    public void PickUp(GameObject player)
    {
        player.GetComponent<Player>().AddWaterAmount(amount);
        player.GetComponent<PlayerAudioHandler>().PlayDrinkSound();
        Destroy(gameObject);
    }
}
