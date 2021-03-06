﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Presenter;
using UnityEngine.EventSystems;

namespace UI.View
{
    public class InventorySlot : Slot
    {
        InventoryPresenter invenPresenter;
        public void SlotInitialize(InventoryPresenter presenter)
        {
            
            SlotInitialize();
            invenPresenter = presenter;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            invenPresenter.SelectedSlotIndex = Index;
            if (Input.GetMouseButton(1))
            {
                invenPresenter.UseItem();
            }
          
        }

        public override void OnDrop(PointerEventData eventData)
        {
            invenPresenter.SwapSlot(Index);
        }

    }
}