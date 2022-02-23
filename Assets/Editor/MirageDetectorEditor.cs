using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MirageDetector))]
public class MirageDetectorEditor : Editor
{
    private void OnSceneGUI()
    {
        MirageDetector mirageDetector = (MirageDetector)target;
        Handles.color = Color.red;
        Handles.DrawWireArc(mirageDetector.transform.position, Vector3.up, Vector3.forward, 360, mirageDetector.Range);
    }
}
