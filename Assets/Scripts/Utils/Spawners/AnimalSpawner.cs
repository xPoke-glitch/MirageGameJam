using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : Spawner
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Spawn();
        }
    }
}
