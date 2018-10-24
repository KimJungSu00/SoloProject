using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Manager;

[CustomEditor(typeof(GameDataManager))]
public class GameDataEditor : Editor {

    GameDataManager dataManager;

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        dataManager = target as GameDataManager;
        
        EditorGUILayout.BeginVertical("Box");
        GUILayout.Label("Save Data");
        SaveGUI();
        EditorGUILayout.EndVertical();
        
        EditorGUILayout.BeginVertical("Box");
        GUILayout.Label("Load Data");
        LoadGUI();
        EditorGUILayout.EndVertical();
    }



    void SaveGUI()
    {
        if (GUILayout.Button("Save"))
        {
            dataManager.Save();
        }
    }
    void LoadGUI()
    {
        if (GUILayout.Button("Load"))
        {
            dataManager.Load();
        }
    }

}
