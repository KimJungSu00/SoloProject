using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Inventory : MonoBehaviour {

    [SerializeField]
    int slotCount;
    [SerializeField]
    GameObject slotPrefab;

    GameObject[] slotArray;

    private void Start()
    {
        slotArray = new GameObject[slotCount];
        MakeSlot();
    }

    void MakeSlot()
    {
        for(int i = 0; i<slotCount; i++)
        {
            slotArray[i] = Instantiate(slotPrefab);
            slotArray[i].transform.SetParent(this.transform);
        }
    }
}
