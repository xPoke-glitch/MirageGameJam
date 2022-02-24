using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Animals.Mirage
{
    public class MouseMirage : Mouse
    {
        public override void Die()
        {
            if (!isAlive) return;
            isAlive = false;
            Destroy(this.gameObject);
        }
    }
}