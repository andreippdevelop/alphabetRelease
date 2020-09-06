using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectTargetLinker))]
public class ObjectTargetLinkerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ObjectTargetLinker myScript = (ObjectTargetLinker)target;
        if (GUILayout.Button("Default Initialization"))
        {
            myScript.DefaultInitialization();
        }
    }
}
