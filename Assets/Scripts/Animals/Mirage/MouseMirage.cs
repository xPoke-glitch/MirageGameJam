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
            FindObjectOfType<CameraBlurEffect>().PlayBlurEffect();
            isAlive = false;
            Destroy(this.gameObject);
        }
    }
}