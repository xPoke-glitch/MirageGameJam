using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMirage: Snake
{
    public override void Die()
    {
        if (!isAlive) return;
        FindObjectOfType<CameraBlurEffect>().PlayBlurEffect();
        isAlive = false;
        Destroy(this.gameObject);
    }
}
