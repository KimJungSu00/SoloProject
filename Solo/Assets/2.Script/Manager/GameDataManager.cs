using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using ItemGroup;


public class GameDataManager :Singleton<GameDataManager> {

    public CharacterData characterData = new CharacterData();
   
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

    private void Awake()
    {
        Loaddd();
    }
    void Loaddd()
    {
        string loadData = File.ReadAllText(Application.dataPath + "/Json/PlayerData.Json");

        var fromJson = JsonUtility.FromJson<CharacterData>(loadData);

        characterData.ItemList = fromJson.ItemList;
        characterData.ModuleList = fromJson.ModuleList;
        characterData.ShieldList = fromJson.ShieldList;
        characterData.WeaponList = fromJson.WeaponList;

       
    }

    public void LoadEquipmentStatus(out int hp,out int mp,out int atk,out int def)
    {
        hp = 0;
        mp = 0;
        atk = 0;
        def = 0;
        atk = ItemController.Instance.GetItem(characterData.WeaponList[0].itemCode).AttackPower;
        foreach(InventoryStruct slot in characterData.ShieldList)
        {
            def += ItemController.Instance.GetItem(slot.itemCode).DefencePower;
            hp += ItemController.Instance.GetItem(slot.itemCode).HP;
            mp += ItemController.Instance.GetItem(slot.itemCode).MP;
        }
        foreach(InventoryStruct slot in characterData.ModuleList)
        {
            atk += ItemController.Instance.GetItem(slot.itemCode).AttackPower;
            def += ItemController.Instance.GetItem(slot.itemCode).DefencePower;
            hp += ItemController.Instance.GetItem(slot.itemCode).HP;
            mp += ItemController.Instance.GetItem(slot.itemCode).MP;
        }

    }
    
}
