using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBar : BarIndicator
{
    [SerializeField]
    private Player player;

    protected override float Value => player.Water;

    protected override float MaxValue => player.GetMaxWater();
}
