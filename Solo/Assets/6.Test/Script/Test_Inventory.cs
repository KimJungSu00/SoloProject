using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemGroup;
public enum SlotType
{
    Inventory,
    Equipment,
    Quick,
}

public class Test_Inventory : MonoBehaviour
{

    public Test_Slot SelectSlot;
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
        StartCoroutine(MakeInventorySlot());

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
            slotList[i].Initialze(this, type,ItemController.Instance.GetItem(0));
        }
        yield return new WaitForEndOfFrame();
    }

    public void AddItem(Item item)
    {
        foreach(Test_Slot slot in slotList)
        {
            if (slot.AddItem(item))
                return;
        }
    }
}
