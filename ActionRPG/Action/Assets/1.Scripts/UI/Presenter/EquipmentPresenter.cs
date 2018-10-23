using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Model;
using UI.View;

namespace UI.Presenter
{
    public enum SlotItemType
    {
        Weapon = 0,
        Module = 3,
        Shield = 9,
    }
    public class EquipmentPresenter : MonoBehaviour
    {

        EquipmentSlot[] slotArray;
        EquipmentModel equipModel;

        public int SelectedSlotIndex;

        [SerializeField]
        GameObject[] slotPosition;

        [SerializeField]
        GameObject slotPrefab;

        public void EquipmentInitialzie(EquipmentModel model)
        { 
            equipModel = model;
            MakeSlot();
            model.EquipUpdateDelegate = UpdateSlot;
            UpdateSlot();
        }

        void MakeSlot()
        {
            slotArray = new EquipmentSlot[equipModel.EquipmentCount];
            for (int i = 0; i < equipModel.EquipmentCount; i++)
            {
                slotArray[i] = Instantiate(slotPrefab).GetComponent<EquipmentSlot>();

                if (i <= (int)SlotItemType.Weapon)
                {
                    slotArray[i].transform.SetParent(slotPosition[0].transform);
                }
                else if (i <= (int)SlotItemType.Module)
                {
                    slotArray[i].transform.SetParent(slotPosition[1].transform);
                }
                else
                {
                    if (i < ((int)SlotItemType.Shield / 2) + 3)
                        slotArray[i].transform.SetParent(slotPosition[2].transform);
                    else
                        slotArray[i].transform.SetParent(slotPosition[3].transform);
                }
                slotArray[i].Index = i;
                slotArray[i].SlotInitialize(this);
            }
        }

        public void UpdateSlot()
        {
            for (int i = 0; i < equipModel.EquipmentCount; i++)
            {
                slotArray[i].ItemImage.sprite = equipModel.EquipmentArray[i].Item.Sprite;
            }
        }

        public void UseItem()
        {
            equipModel.UseItem();
        }


    }
}