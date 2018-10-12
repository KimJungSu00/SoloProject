using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInventory : IInventory {

	

    public void UseItem(int index)
    {
        Debug.Log(index);
        slotList[index-1].UseItem();
    }
}
