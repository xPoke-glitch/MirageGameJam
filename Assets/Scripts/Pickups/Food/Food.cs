using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IPickable
{
    [SerializeField] private FoodData _food;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            PickUp(collision.gameObject);
    }


    public void PickUp(GameObject player)
    {
        player.GetComponent<Player>().AddFoodAmount(_food.Value);
        Destroy(gameObject);
    }
}
