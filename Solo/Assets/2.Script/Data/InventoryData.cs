using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Presenter;
namespace Data
{
    public struct InventoryStruct
    {
        public int index;
        public int itemCode;
        public int itemCount;
    }
    public class InventoryData : MonoBehaviour
    {
        [SerializeField]
        InventoryStruct[] invenData;
        Inventory inventory;

        private void Start()
        {
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
            invenData = new InventoryStruct[inventory.SlotList.Count];
        }

        public void AddItem(ItemGroup.Item item)
        {
            inventory.AddItem(item);
        }
        
        public void SaveInventoryData()
        {
            int j = 0;
            invenData = new InventoryStruct[inventory.SlotList.Count];
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
        }
    }

}