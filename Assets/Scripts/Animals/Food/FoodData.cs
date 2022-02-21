using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "Food/SpawnFood", order = 1)]
public class FoodData : ScriptableObject
{
    public string Name;
    public int Value;
    public GameObject Prefab;
}

