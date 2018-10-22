﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Model;
using UI.View;


namespace UI.Presenter
{
    public class InventoryPresenter : MonoBehaviour
    {

        InventorySlot[] slotArray;
        InventoryModel invenModel;

        [SerializeField]
        GameObject slotPrefab;

        public int SelectedSlotIndex;
        
        public void InventoryInitialize(InventoryModel model)
        {
            invenModel = model;
            MakeSlot();
            invenModel.AddItemDelegate = SlotUpdate;
            SlotUpdate();
        }

        void MakeSlot()
        {
            slotArray = new InventorySlot[invenModel.InventoryCount];
            for(int i = 0; i < slotArray.Length; i++)
            {
                slotArray[i] = Instantiate(slotPrefab).GetComponent<InventorySlot>();
                slotArray[i].transform.SetParent(gameObject.transform);
                slotArray[i].name = "Slot [" + i + "]";
                slotArray[i].Index = i;
                slotArray[i].SlotInitialize(this);
            }
        }

        public void SlotUpdate()
        {
            for (int i = 0; i < slotArray.Length; i++)
            {
                slotArray[i].ItemImage.sprite = invenModel.ItemArray[i].Item.Sprite;
                slotArray[i].ItemCount.text = invenModel.ItemArray[i].ItemCount.ToString();
                if (invenModel.ItemArray[i].ItemCount <= 1)
                {
                    slotArray[i].ItemCount.text = string.Empty;
                }
            }
        }

        public void SlotSwap(int index)
        {
            invenModel.SwapItem(SelectedSlotIndex, index);
            SlotUpdate();
        }

        public void SortInventory()
        {
            if (invenModel.Sort())
                SlotUpdate();
        }
    }
}