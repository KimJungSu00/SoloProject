using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ItemGroup;
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
            slotList[i].Initialize(this, type, ItemController.Instance.GetItem(0));
        }

        yield return new WaitForEndOfFrame();
    }
    IEnumerator InitializeInventory()
    {

        foreach (Slot slots in slotList)
        {
            slots.Initialize(this, type, ItemController.Instance.GetItem(0));
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

}
