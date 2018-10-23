using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemGroup;
using UI.Presenter;
using System;
using Manager;

namespace UI.Model
{
    [Serializable]
    public struct ItemStruct
    {
        
        public Item Item;
        public bool IsFull;
        public int ItemCount;
    }
    public delegate void UpdateInvenSlotDelegate();

    public class InventoryModel : MonoBehaviour , IItemExchangeable
    {
        public const int INVENTORYCOUNT = 35;
        InventoryPresenter invenPresenter;
        public int InventoryCount { get { return INVENTORYCOUNT; } private set { } }
        public ItemStruct[] ItemArray { get; private set; }
        public UpdateInvenSlotDelegate InvenUpdateDelegate;

        ItemMediator mediator;

        private void Start()
        {
            InventoryInitialize();
        }

        public bool InventoryInitialize()
        {
            ItemArray = new ItemStruct[INVENTORYCOUNT];
            mediator = GameObject.FindGameObjectWithTag("ItemMediator").GetComponent<ItemMediator>();
            for (int i =0; i< INVENTORYCOUNT; i++)
            {
                ItemArray[i].Item = ItemController.Instance.GetItem(0);
             
            }
            invenPresenter = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryPresenter>();
            invenPresenter.InventoryInitialize(this);
            GameDataManager.Instance.loadCallback += LoadItem;
            return true;
        }

        public void AddItem(Item item)
        {
            if (item.ItemType == ItemType.Default)
                return;
            for(int i = 0; i < INVENTORYCOUNT; i++)
            {
                if(ItemArray[i].Item.Code == item.Code && ItemArray[i].ItemCount < item.MaxCount)
                {
                    ItemArray[i].ItemCount++;
                    ItemArray[i].IsFull = true;
                    break;
                }
                if(!ItemArray[i].IsFull)
                {
                    ItemArray[i].Item = item;
                    ItemArray[i].ItemCount = 1;
                    ItemArray[i].IsFull = true;
                    break;
                }
            }
            InvenUpdateDelegate();
        }

        void ResetItem()
        {
            for(int i = 0; i < INVENTORYCOUNT; i ++)
            {
                if(ItemArray[i].ItemCount == 0)
                {
                    ItemArray[i].Item = ItemController.Instance.GetItem(0);
                    ItemArray[i].IsFull = false;
                }
            }
            InvenUpdateDelegate();
        }

        public bool Sort()
        {
            ItemStruct[] buffer = new ItemStruct[INVENTORYCOUNT * 2];
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

        public void SwapItem(int indexA, int indexB)
        {
            if(ItemArray[indexA].Item.Code == ItemArray[indexB].Item.Code)
            {
                ItemArray[indexB].ItemCount += ItemArray[indexA].ItemCount;
                ItemArray[indexA].ItemCount = 0;
                if(ItemArray[indexB].ItemCount > ItemArray[indexB].Item.MaxCount)
                {
                    ItemArray[indexA].ItemCount = ItemArray[indexB].ItemCount % ItemArray[indexB].Item.MaxCount;
                    ItemArray[indexB].ItemCount = ItemArray[indexB].Item.MaxCount;
                }
                else
                {
                    Swap(indexA, indexB);
                }
            }
            else
                Swap(indexA, indexB);
            ResetItem();
        }

        void Swap(int indexA, int indexB)
        {
            ItemStruct temp = ItemArray[indexA];
            ItemArray[indexA] = ItemArray[indexB];
            ItemArray[indexB] = temp;
        }

        public void Send()
        {
            mediator.SendItem(ItemArray[invenPresenter.SelectedSlotIndex], this);
            ItemArray[invenPresenter.SelectedSlotIndex].Item = ItemController.Instance.GetItem(0);
            ItemArray[invenPresenter.SelectedSlotIndex].IsFull = false;
            InvenUpdateDelegate();
        }

        public void Receive(ItemStruct item)
        {
            AddItem(item.Item);
            InvenUpdateDelegate();
        }
        
        public bool UseItem()
        {
            if(ItemArray[invenPresenter.SelectedSlotIndex].Item.ItemType == ItemType.Consume)
            {
                ItemArray[invenPresenter.SelectedSlotIndex].ItemCount--;
            }
            else if(ItemArray[invenPresenter.SelectedSlotIndex].Item.ItemType != ItemType.Default)
            {
                Send();
            }
            ResetItem();
            return true;
        }

        public void LoadItem()
        {
            ItemArray = GameDataManager.Instance.playerdata.InventoryArray;
            for(int i = 0; i < ItemArray.Length; i++)
            {
                ItemArray[i].Item = ItemController.Instance.GetItem(ItemArray[i].Item.Code);
            }
            InvenUpdateDelegate();
        }
    }


}