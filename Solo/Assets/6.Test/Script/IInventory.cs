using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ItemGroup;
using System.IO;

[Serializable]
public class InventoryStruct
{
    public int index;
    public int itemCode;
    public int itemCount;
}
public class IInventory : MonoBehaviour {

    [SerializeField]
    public List<Slot> slotList = new List<Slot>();

    [SerializeField]
    int rowCount;
    [SerializeField]
    GameObject slot;
    [SerializeField]
    SlotType type;

    private void Start()
    {
        Initialize();
        GameDataManager.Instance.LoadEvent += new EventHandler(LoadData);
    }
    

    bool Initialize()
    {
        if (type == SlotType.Inventory)
            StartCoroutine(MakeInventorySlot());
        else
            StartCoroutine(InitializeInventory());
        return true;
    }


    IEnumerator MakeInventorySlot()
    {
        rowCount *= 7;

        for (int i = 0; i < rowCount; i++)
        {
            slotList.Add(Instantiate(slot).GetComponent<Slot>());
            slotList[i].transform.SetParent(transform, false);
            slotList[i].name = "Slot [" + i + "]";
            slotList[i].Initialize(this, type, ItemController.Instance.GetItem(0),i);
        }

        yield return new WaitForEndOfFrame();
    }
    IEnumerator InitializeInventory()
    {
        int index = 0;
        foreach (Slot slots in slotList)
        {
            slots.Initialize(this, type, ItemController.Instance.GetItem(0),index);
            index++;
        }
        yield return new WaitForEndOfFrame();
    }

    public void AddItem(Item item)
    {
        foreach (Slot slot in slotList)
        {
            if (slot.AddItem(item))
                return;
        }
    }

    public void LoadData(object sender, EventArgs e)
    {
        string loadData = File.ReadAllText(Application.dataPath + "/Json/PlayerData.Json");

        var fromJson = JsonUtility.FromJson<CharacterData>(loadData);
        List<InventoryStruct> loadList = null;
        switch (type)
        {
            case SlotType.Weapon:
                loadList = fromJson.WeaponList;
                break;
            case SlotType.Module:
                loadList = fromJson.ModuleList;
                break;
            case SlotType.Shield:
                loadList = fromJson.ShieldList;
                break;
            case SlotType.Inventory:
                loadList = fromJson.ItemList;
                break;           
        }
        if(loadList!=null)
        foreach(InventoryStruct slot in loadList)
        {
            slotList[slot.index].LoadItem(ItemController.Instance.GetItem(slot.itemCode), slot.itemCount);
        }
    }

}
