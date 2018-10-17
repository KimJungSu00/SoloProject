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
        }
        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
            inventory.Previousindex = index;
        }
        public override void OnDrop(PointerEventData eventData)
        {
            inventory.SwapInventory(index);
        }
    }
}