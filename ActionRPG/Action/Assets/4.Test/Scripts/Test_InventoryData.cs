using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemGroup;

namespace Test
{
    public struct ItemStruct
    {
        public Item Item;
        public bool IsFull;
        public int ItemCount;
    }

    public class Test_InventoryData : MonoBehaviour, IGameDatable
    {
        [SerializeField]
        Test_Inventory inventory;
        public ItemStruct[] ItemArray;
        ItemStruct[] buffer;
        [SerializeField]
        Test_GameMediator mediator;
        private void Start()
        {
            ItemArray = new ItemStruct[inventory.SlotCount];
            buffer = new ItemStruct[ItemArray.Length * 2];
            for (int i = 0; i < ItemArray.Length; i++)
            {
                ItemArray[i].Item = ItemController.Instance.GetItem(0);
            }
        }

        public void AddItem(Item item)
        {
            for (int i = 0; i < ItemArray.Length; i++)
            {
                if (ItemArray[i].Item.Code == item.Code && ItemArray[i].ItemCount < item.MaxCount)
                {
                    ItemArray[i].ItemCount++;
                    ItemArray[i].IsFull = true;

                    break;
                }
                if (!ItemArray[i].IsFull)
                {
                    ItemArray[i].Item = item;
                    ItemArray[i].ItemCount = 1;
                    ItemArray[i].IsFull = true;

                    break;
                }
            }
        }

        public void RemoveItem()
        {
            for (int i = 0; i < ItemArray.Length; i++)
            {
                if (ItemArray[i].ItemCount == 0)
                {
                    ItemArray[i].Item = ItemController.Instance.GetItem(0);
                    ItemArray[i].IsFull = false;

                }
            }
        }

        public void EquipItem()
        {

        }


        public bool Sort()
        {
            MergeSort(ItemArray, buffer, 0, ItemArray.Length - 1);
            return true;
        }

        void MergeSort(ItemStruct[] arr, ItemStruct[] buffer, int start, int end)
        {
            int middle = 0;
            if (start < end)
            {
                middle = (start + end) / 2;
                MergeSort(arr, buffer, start, middle);
                MergeSort(arr, buffer, middle + 1, end);
                MergeSortInternal(arr, buffer, start, middle, end);
            }
        }

        void MergeSortInternal(ItemStruct[] arr, ItemStruct[] buffer, int start, int middle, int end)
        {
            int i = start;
            int j = middle + 1;
            int k = start;
            int t;

            while (i <= middle && j <= end)
            {
                if (arr[i].Item.Code > arr[j].Item.Code)
                {
                    buffer[k] = arr[i];
                    i++;
                }
                else if (arr[i].Item.Code == arr[j].Item.Code)
                {
                    if (arr[i].ItemCount >= arr[j].ItemCount)
                    {
                        buffer[k] = arr[i];
                        i++;
                    }
                    else
                    {
                        buffer[k] = arr[j];
                        j++;
                    }
                }
                else
                {
                    buffer[k] = arr[j];
                    j++;
                }
                k++;
            }
            if (i > middle)
                for (t = j; t <= end; t++, k++)
                    buffer[k] = arr[t];
            else
                for (t = i; t <= middle; t++, k++)
                    buffer[k] = arr[t];

            for (t = start; t <= end; t++)
                arr[t] = buffer[t];
        }

        public void SendItem()
        {
            mediator.Send(ItemArray[inventory.Previousindex], this);

            ItemArray[inventory.Previousindex].Item = ItemController.Instance.GetItem(0);
            ItemArray[inventory.Previousindex].ItemCount = 0;
            ItemArray[inventory.Previousindex].IsFull = false;

            inventory.SlotUpdate();
        }

        public void ReceiveItem(ItemStruct item)
        {
            for (int i = 0; i < ItemArray.Length; i++)
            {
                if (!ItemArray[i].IsFull)
                {
                    ItemArray[i] = item;
                    break;
                }
            }
            inventory.SlotUpdate();
        }
    }

}