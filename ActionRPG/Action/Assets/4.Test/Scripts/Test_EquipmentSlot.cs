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
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
            
        }
        public override void OnDrop(PointerEventData eventData)
        {
        }

    }
}