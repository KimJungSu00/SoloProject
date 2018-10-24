using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UI.Presenter;
using ItemGroup;

[CustomEditor(typeof (EquipmentPresenter))]
public class EquipmentPresenterEditor : Editor {

    
    
    EquipmentPresenter presenter;
    private void OnEnable()
    {
        presenter = target as EquipmentPresenter;
    }
    public override void OnInspectorGUI()
    {
        
        SlotPrefabGUI();
        EquipGUI();
       
    }
    
    void EquipGUI()
    {
        GUILayout.BeginHorizontal("Box");
        GUILayout.BeginVertical();
        GUILayout.Label("Slot Make Position");
        GUILayout.Label("Weapon");
        presenter.SlotPosition[0] = (GameObject)EditorGUILayout.ObjectField(presenter.SlotPosition[0], typeof(GameObject), true);
        GUILayout.Label("Module");
        presenter.SlotPosition[1] = (GameObject)EditorGUILayout.ObjectField(presenter.SlotPosition[1], typeof(GameObject), true);
        GUILayout.Label("TopShield");
        presenter.SlotPosition[2] = (GameObject)EditorGUILayout.ObjectField(presenter.SlotPosition[2], typeof(GameObject), true);
        GUILayout.Label("BottomShield");
        presenter.SlotPosition[3] = (GameObject)EditorGUILayout.ObjectField(presenter.SlotPosition[3], typeof(GameObject), true);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }

    void SlotPrefabGUI()
    {
        GUILayout.BeginHorizontal("Box");
        GUILayout.BeginVertical();
        GUILayout.Label("Equip Slot Prefab");
        presenter.SlotPrefab = (GameObject)EditorGUILayout.ObjectField(presenter.SlotPrefab, typeof(GameObject), true);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }

   
}
