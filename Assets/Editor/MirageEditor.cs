using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Mirage))]
public class MirageEditor : Editor
{
    private void OnSceneGUI()
    {
        Mirage mirage = (Mirage)target;
        Handles.color = Color.red;
        Handles.DrawWireArc(mirage.transform.position, Vector3.up, Vector3.forward, 360, mirage.Radius);
    }
}

