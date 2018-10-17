using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemGroup;
namespace Test
{
    public class Test_EquipmentData : MonoBehaviour, IGameDatable
    {
        public ItemStruct[] EquipmentArray;


        [SerializeField]
        Test_Equipment equipmentPresenter;

        [SerializeField]
        Test_GameMediator mediator;
        private void Start()
        {
            MakeSlotData();
            equipmentPresenter.SlotUpdate();
        }
        void MakeSlotData()
        {
            EquipmentArray = new ItemStruct[10];
            for (int i = 0; i < EquipmentArray.Length; i++)
            {
                EquipmentArray[i].Item = ItemController.Instance.GetItem(0);
            }
            equipmentPresenter.SlotUpdate();
        }

        public void SendItem()
        {
            mediator.Send(EquipmentArray[equipmentPresenter.Previousindex], this);

            EquipmentArray[equipmentPresenter.Previousindex].Item = ItemController.Instance.GetItem(0);
            EquipmentArray[equipmentPresenter.Previousindex].ItemCount = 0;
            EquipmentArray[equipmentPresenter.Previousindex].IsFull = false;

            equipmentPresenter.SlotUpdate();
        }

        public void ReceiveItem(ItemStruct item)
        {
            bool isSucces = false;
            for (int i = 0; i < EquipmentArray.Length; i++)
            {
                if (isSucces)
                    continue;
                if (i == (int)EquipType.Weapon && item.Item.ItemType == ItemType.Weapon)
                {
                    if (!EquipmentArray[i].IsFull)
                    {
                        EquipmentArray[(int)EquipType.Weapon] = item;
                        isSucces = true;
                    }
                }
                else if (i <= (int)EquipType.Module && i != 0 
                    && item.Item.ItemType == ItemType.Module)
                {
                    if (!EquipmentArray[i].IsFull)
                    {
                        EquipmentArray[i] = item;
                        isSucces = true;
                    }
                }
                else if (i <= (int)EquipType.Shield && i > (int)EquipType.Module
                    && item.Item.ItemType == ItemType.Shield)
                {
                    if (!EquipmentArray[i].IsFull)
                    {
                        EquipmentArray[i] = item;
                        isSucces = true;
                    }
                }

            }
            if (!isSucces)
                mediator.Send(item, this);
            equipmentPresenter.SlotUpdate();
        }
    }
}