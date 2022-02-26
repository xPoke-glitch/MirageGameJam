using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IPickable
{
    [SerializeField] private FoodData _food;
    bool _allowedToPickup = false;

    private void OnEnable()
    {
        Invoke("TriggerDelay", 2);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (_allowedToPickup)
        {
            if (collision.gameObject.CompareTag("Player"))
                PickUp(collision.gameObject);
        }
        else { return; }
    }

    void TriggerDelay()
    {
        _allowedToPickup = true;
    }

    public void PickUp(GameObject player)
    {
        player.GetComponent<Player>().AddFoodAmount(_food.Value);
        CancelInvoke();
        Destroy(gameObject);
    }
}
