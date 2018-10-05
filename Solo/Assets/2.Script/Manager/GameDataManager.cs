using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;



public class GameDataManager :Singleton<GameDataManager> {

    CharacterData characterData = new CharacterData();
   
    public void AddData(int index, int itemCode, int count, SlotType type)
    {
        List<InventoryStruct> dataList = null;
        switch (type)
        {
            case SlotType.Weapon:
                dataList = characterData.WeaponList;
                break;
            case SlotType.Module:
                dataList = characterData.ModuleList;
                break;
            case SlotType.Shield:
                dataList = characterData.ShieldList;
                break;
            case SlotType.Inventory:
                dataList = characterData.ItemList;
                break;
        }
        InventoryStruct data = new InventoryStruct
        {
            index = index,
            itemCode = itemCode,
            itemCount = count
        };
        if(dataList != null)
        dataList.Add(data);
    }
    public void UpdateData(int index, int itemCode , int count, SlotType type)
    {
        List<InventoryStruct> dataList = null;
        switch (type)
        {
            case SlotType.Weapon:
                dataList = characterData.WeaponList;
                break;
            case SlotType.Module:
                dataList = characterData.ModuleList;
                break;
            case SlotType.Shield:
                dataList = characterData.ShieldList;
                break;
            case SlotType.Inventory:
                dataList = characterData.ItemList;
                break;
        }

        if (dataList != null)
        {
            foreach (InventoryStruct list in dataList)
            {
                if (list.index == index)
                {
                    list.index = index;
                    list.itemCount = count;
                    list.itemCode = itemCode;
                    break;
                }
            }
        }
    }

    public event EventHandler LoadEvent;

    public void SaveData()
    {
        string toJson = JsonUtility.ToJson(characterData, prettyPrint: true);
        using (StreamWriter file = new StreamWriter(Application.dataPath + "/Json/PlayerData.Json", false))
        {
            file.WriteLine(toJson);
            Debug.Log(toJson);
        }
    }
    public void LoadData()
    {
        if(LoadEvent != null)
        {
            LoadEvent(this, EventArgs.Empty);
        }
    }
    
  
    
}
