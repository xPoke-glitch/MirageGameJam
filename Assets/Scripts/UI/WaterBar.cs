using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBar : BarIndicator
{
    [SerializeField]
    private Player player;

    public override float Value => player.Water;

    public override float MaxValue => player.GetMaxWater();

}
