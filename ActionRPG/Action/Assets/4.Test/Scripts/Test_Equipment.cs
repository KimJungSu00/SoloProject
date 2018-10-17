using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    
    public class Test_Equipment : MonoBehaviour
    {
        [SerializeField]
        public Test_Slot weaponSlot;
        [SerializeField]
        public Test_Slot[] moduleSlot;
        [SerializeField]
        public Test_Slot[] sheildslot;

        [SerializeField]
        Test_EquipmentData model;
        public void SlotUpdate()
        {
            weaponSlot.slotImage.sprite = model.Weapon.Item.Sprite;

            for(int i = 0; i < model.Module.Length;i++)
            {
                moduleSlot[i].slotImage.sprite = model.Module[i].Item.Sprite;
            }
            for(int i = 0; i < model.Shield.Length;i++)
            {
                sheildslot[i].slotImage.sprite = model.Shield[i].Item.Sprite;
            }
        }

    }
}

