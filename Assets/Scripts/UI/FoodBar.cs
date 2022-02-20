using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBar : BarIndicator
{
    [SerializeField]
    private Player player;

    protected override float Value => player.Food;

    protected override float MaxValue => player.GetMaxFood();

}
