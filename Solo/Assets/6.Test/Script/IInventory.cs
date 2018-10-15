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
public class IInventory : MonoBehaviour
{

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
            slotList[i].Initialize(this, type, ItemController.Instance.GetItem(0), i);
        }

        yield return new WaitForEndOfFrame();
    }
    IEnumerator InitializeInventory()
    {
        int index = 0;
        foreach (Slot slots in slotList)
        {
            slots.Initialize(this, type, ItemController.Instance.GetItem(0), index);
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

        List<InventoryStruct> loadList = null;
        switch (type)
        {
            case SlotType.Weapon:
                loadList = GameDataManager.Instance.characterData.WeaponList;
                break;
            case SlotType.Module:
                loadList = GameDataManager.Instance.characterData.ModuleList;
                break;
            case SlotType.Shield:
                loadList = GameDataManager.Instance.characterData.ShieldList;
                break;
            case SlotType.Inventory:
                loadList = GameDataManager.Instance.characterData.ItemList;
                break;
        }
        if (loadList != null)
            foreach (InventoryStruct slot in loadList)
            {
                if (slot.itemCode == 0)
                    continue;
                slotList[slot.index].LoadItem(ItemController.Instance.GetItem(slot.itemCode), slot.itemCount);
            }
    }

    public void SortSlot()
    {
        QuickSort(slotList, 0, slotList.Count - 1);

    }

    void QuickSort(List<Slot> slotList, int start, int end)
    {
        int pivot = 0;
        if (start < end)
        {
            pivot = PartitionQuciSort(slotList, start, end);
            QuickSort(slotList, start, pivot - 1);
            QuickSort(slotList, pivot + 1, end);
        }
    }

    int PartitionQuciSort(List<Slot> slotList, int start, int end)
    {
        int pivot = end;
        int right = end;
        int left = start;

        while (left < right)
        {
            while ((slotList[left].ItemCode >= slotList[pivot].ItemCode) && (left < right))
            {
                left++;
            }
            while ((slotList[right].ItemCode < slotList[pivot].ItemCode) && (left < right))
            {
                right--;
            }
            if (left < right)
            {
                slotList[left].SlotSwap(slotList[left], slotList[right]);
            }
        }
        slotList[right].SlotSwap(slotList[pivot], slotList[right]);

        return right;
    }

}
