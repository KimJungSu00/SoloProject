using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Test
{
    public class Test_InventorySlot : Test_Slot
    {
        Test_Inventory inventory;
        protected override void Awake()
        {
            base.Awake();  
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Test_Inventory>();
            type = SlotType.Inventory;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (Input.GetMouseButton(1))
            {
                inventory.Previousindex = index;
                inventory.SendItem();
            }
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
            inventory.Previousindex = index;
        }

        public override void OnDrop(PointerEventData eventData)
        {
            if (dragitem.PreSolt.type == type)
            {
                inventory.SwapInventory(index);
            }
            else
            {
                inventory.SendItem();
            }
        }

        public void Send()
        {
            inventory.SendItem();
        }
    }
}