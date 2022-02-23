using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spawner), true)]
public class SpawnerEditor : Editor
{
    private void OnSceneGUI()
    {
        Spawner spawner = (Spawner)target;
        Handles.color = Color.red;
        Handles.DrawWireArc(spawner.transform.position, Vector3.up, Vector3.forward, 360, spawner.Range);
    }
}
