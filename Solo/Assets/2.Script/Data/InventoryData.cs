using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Presenter;
using System;
using ManagerGroup;
namespace Data
{
    [Serializable]
    public struct InventoryStruct
    {
        public int index;
        public int itemCode;
        public int itemCount;
    }
    public class InventoryData : MonoBehaviour
    {
        [SerializeField]
        public InventoryStruct[] invenData;
       // public Dictionary<int, InventoryStruct> invenData;
        Inventory inventory;

        private void Start()
        {
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
            invenData = new InventoryStruct[inventory.SlotList.Count];
           // invenData = new Dictionary<int, InventoryStruct>();
        }

        public void AddItem(ItemGroup.Item item)
        {
            inventory.AddItem(item);
        }
        
        public void SaveInventoryData()
        {
            int j = 0;
              invenData = new InventoryStruct[inventory.SlotList.Count];
           // invenData = new Dictionary<int, InventoryStruct>();
            for (int i = 0; i< inventory.SlotList.Count; i++)
            {
                if(inventory.SlotList[i].ItemCode !=0)
                {
                      invenData[j].index = i;
                     invenData[j].itemCode = inventory.SlotList[i].ItemCode;
                      invenData[j].itemCount = inventory.SlotList[i].ItemCount;

                    j++;
                }
            }

            JsonManager.Instance.OnClickSaveJSONBtn();
        }
    }

}