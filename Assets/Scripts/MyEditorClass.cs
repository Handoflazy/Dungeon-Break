using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;
[CanEditMultipleObjects]
[CustomEditor(typeof(GunWeaponDataSO))]
public class MyEditorClass : Editor
{
    SerializedProperty aBool;
    SerializedProperty bInt;
    private void OnEnable()
    {
        aBool = serializedObject.FindProperty("aBool");
        bInt = serializedObject.FindProperty("aFloat");
    }
}
