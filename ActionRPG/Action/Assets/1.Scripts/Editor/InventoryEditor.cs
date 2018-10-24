using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UI.Model;
using ItemGroup;

[CustomEditor(typeof(InventoryModel))]
public class InventoryEditor : Editor
{
    InventoryModel invenModel;
    int selected = 0;
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        invenModel = target as InventoryModel;



        EditorGUILayout.BeginVertical("Box");
        AddItemGUI();
        EditorGUILayout.EndVertical();
    }

    void AddItemGUI()
    {
        GUILayout.Label("Add Item");
        EditorGUILayout.BeginHorizontal();
        ItemTable table = Resources.Load<ItemTable>("ItemTable");
        string[] items = new string[table.sheets[0].list.Count];
        int[] itemCode = new int[table.sheets[0].list.Count];
        for(int i = 1; i< items.Length;i++)
        {
            items[i] = table.sheets[0].list[i].Name;
            itemCode[i] = table.sheets[0].list[i].ID;
        } 
        selected = EditorGUILayout.Popup("", selected, items);
        if (GUILayout.Button("Add"))
        {
            invenModel.AddItem(ItemController.Instance.GetItem(itemCode[selected]));
        }
        EditorGUILayout.EndHorizontal();
    }
}
