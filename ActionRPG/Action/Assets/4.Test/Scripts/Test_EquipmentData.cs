using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemGroup;
namespace Test
{
    public class Test_EquipmentData : MonoBehaviour
    {
        public ItemStruct Weapon;
        public ItemStruct[] Module;
        public ItemStruct[] Shield;

        [SerializeField]
        Test_Equipment equipmentPresenter;

        private void Start()
        {
            MakeSlotData();
            equipmentPresenter.SlotUpdate();
        }
        void MakeSlotData()
        {
            Weapon.Item = ItemController.Instance.GetItem(0);
            Module = new ItemStruct[equipmentPresenter.moduleSlot.Length-1];
            for(int i = 0; i < Module.Length;i++)
            {
                Module[i].Item = ItemController.Instance.GetItem(0);
            }
            Shield = new ItemStruct[equipmentPresenter.sheildslot.Length-1];
            for (int i = 0; i < Shield.Length; i++)
            {
                Shield[i].Item = ItemController.Instance.GetItem(0);
            }
        }
       


    }
}