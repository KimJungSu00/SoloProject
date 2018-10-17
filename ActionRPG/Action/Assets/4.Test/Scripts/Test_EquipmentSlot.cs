using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Test
{
    public class Test_EquipmentSlot : Test_Slot
    {
        Test_Equipment equipWindow;
        protected override void Awake()
        {
            base.Awake();
            equipWindow = GameObject.FindGameObjectWithTag("Equipment").GetComponent<Test_Equipment>();
            type = SlotType.Equipment;
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
            
        }
        public override void OnDrop(PointerEventData eventData)
        {
            if (dragitem.PreSolt.type == type)
            {
                Debug.Log("같은 슬롯타입");
               // equipWindow.SwapInventory(index);
            }
            else
            {
                Debug.Log("다른 슬롯타입");
                if (dragitem.PreSolt is Test_InventorySlot)
                {
                    Test_InventorySlot slot = dragitem.PreSolt as Test_InventorySlot;
                    slot.Send();
                }
            }
        }

       

    }
}