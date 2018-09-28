using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemGroup;
using System;
using UI.Presenter;

public enum SlotType
{
    Weapon,
    Module,
    Shield,
    Consume,
    Inventory,
}


public class Test_Inventory : MonoBehaviour
{
    [SerializeField]
    List<Test_Slot> slotList = new List<Test_Slot>();

    [SerializeField]
    int rowCount;
    [SerializeField]
    GameObject slot;
    [SerializeField]
    SlotType type;

    private void Start()
    {
        Initialize();
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
            slotList.Add(Instantiate(slot).GetComponent<Test_Slot>());
            slotList[i].transform.SetParent(transform, false);
            slotList[i].name = "Slot [" + i + "]";
            slotList[i].Initialze(this, type, ItemController.Instance.GetItem(0));
        }

        yield return new WaitForEndOfFrame();
    }
    IEnumerator InitializeInventory()
    {

        foreach (Test_Slot slots in slotList)
        {
            slots.Initialze(this, type, ItemController.Instance.GetItem(0));
        }
        yield return new WaitForEndOfFrame();
    }

    public void AddItem(Item item)
    {
        foreach (Test_Slot slot in slotList)
        {
            if (slot.AddItem(item))
                return;
        }
    }
}
