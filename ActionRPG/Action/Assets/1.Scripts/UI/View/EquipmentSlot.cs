using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UI.Presenter;

namespace UI.View
{
    public class EquipmentSlot : Slot
    {
        EquipmentPresenter equipmentPresenter;
        
        public void SlotInitialize(EquipmentPresenter presenter)
        {
            dragItem = GameObject.FindGameObjectWithTag("DragItem").GetComponent<DragItem>();
            ItemImage = GetComponent<Image>();
            equipmentPresenter = presenter;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            equipmentPresenter.SelectedSlotIndex = Index;
            if (Input.GetMouseButton(1))
            {
                equipmentPresenter.UseItem();
            }
        }

        public override void OnDrop(PointerEventData eventData)
        {
            
        }

    }
}