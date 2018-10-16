using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ItemGroup;

namespace Test
{
    public struct ItemStruct
    {
        public Item item;
        public bool isFull;
        public int itemCount;
    }

    [Serializable]
    public class Test_InventoryData : MonoBehaviour
    {
        [SerializeField]
        Test_Inventory inventory;
        public ItemStruct[] ItemArray;

        private void Start()
        {
            ItemArray = new ItemStruct[inventory.SlotCount];
            for (int i = 0; i < ItemArray.Length; i++)
            {
                ItemArray[i].item = ItemController.Instance.GetItem(0);
            }
        }

        public void AddItem(Item item)
        {
            for (int i = 0; i < ItemArray.Length; i++)
            {
                if (ItemArray[i].item.Code == item.Code && ItemArray[i].itemCount < item.ItemMaxCount)
                {
                    ItemArray[i].itemCount++;
                    ItemArray[i].isFull = true;
                    break;
                }
                if (!ItemArray[i].isFull)
                {
                    ItemArray[i].item = item;
                    ItemArray[i].itemCount = 1;
                    ItemArray[i].isFull = true;
                    break;
                }
            }
        }

        public void RemoveItem()
        {
            for (int i = 0; i < ItemArray.Length; i++)
            {
               if(ItemArray[i].itemCount == 0)
                {
                    ItemArray[i].item = ItemController.Instance.GetItem(0);
                    ItemArray[i].isFull = false;
                }
            }
        }
        public bool Sort()
        {
            return true;
        }


    }

}