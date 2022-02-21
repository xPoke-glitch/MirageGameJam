using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Animal), true)]
public class AnimalEditor : Editor
{
    private void OnSceneGUI()
    {
        Animal animal = (Animal)target;
        Handles.color = Color.green;
        Handles.DrawWireArc(animal.transform.position, Vector3.up, Vector3.forward, 360, animal.Radius);
    }
}
