using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public enum EquipType
    {
        Weapon = 0,
        Module = 3,
        Shield = 9,
    }
    public class Test_Equipment : MonoBehaviour
    {
        [SerializeField]
        public Test_Slot[] EquipSlot;


        [SerializeField]
        Test_EquipmentData model;

        public Test_Slot SelectedSlot;
        public int Previousindex;

        public void SlotUpdate()
        {
            for (int i = 0; i < EquipSlot.Length; i++)
            {  
                EquipSlot[i].slotImage.sprite = model.EquipmentArray[i].Item.Sprite;
                EquipSlot[i].index = i;
            }
        }

        public void SendItem()
        {
            model.SendItem();
        }
    }
}

