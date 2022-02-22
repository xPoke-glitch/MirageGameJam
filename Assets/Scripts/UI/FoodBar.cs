using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBar : BarIndicator
{
    [SerializeField]
    private Player player;

    public override float Value => player.Food;

    public override float MaxValue => player.GetMaxFood();

}
