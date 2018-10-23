using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Presenter;
using ItemGroup;
using Manager;

namespace UI.Model
{
    public delegate void UpdateEquipSlotDelegate();

    public class EquipmentModel : MonoBehaviour, IItemExchangeable
    {
        const int EQUIPMENTCOUNT = 10;
        public int EquipmentCount { get { return EQUIPMENTCOUNT; } private set { } }
        EquipmentPresenter equipPresenter;
        public ItemStruct[] EquipmentArray { get; private set; }
        public UpdateEquipSlotDelegate EquipUpdateDelegate;

        ItemMediator mediator;

        private void Start()
        {
            EqipmentInitialize();
        }
        public bool EqipmentInitialize()
        {
            EquipmentArray = new ItemStruct[EQUIPMENTCOUNT];
            mediator = GameObject.FindGameObjectWithTag("ItemMediator").GetComponent<ItemMediator>();
            for (int i = 0; i < EQUIPMENTCOUNT; i++)
            {
                EquipmentArray[i].Item = ItemController.Instance.GetItem(0);
            }
            equipPresenter = GameObject.FindGameObjectWithTag("Equipment").GetComponent<EquipmentPresenter>();
            equipPresenter.EquipmentInitialzie(this);
            GameDataManager.Instance.loadCallback += LoadItem;
            return true;
        }

        public void Send()
        {
            mediator.SendItem(EquipmentArray[equipPresenter.SelectedSlotIndex], this);
            EquipmentArray[equipPresenter.SelectedSlotIndex].Item = ItemController.Instance.GetItem(0);
            EquipmentArray[equipPresenter.SelectedSlotIndex].IsFull = false;
            EquipUpdateDelegate();

        }

        public void Receive(ItemStruct item)
        {
            bool isSucces = false;
            if (((int)item.Item.ItemType ^ 8) == 0 && !isSucces)// Weapon
            {
                mediator.SendItem(EquipmentArray[0], this);
                EquipmentArray[0] = item;
                isSucces = true;
            }
            if (((int)item.Item.ItemType ^ 4) == 0 && !isSucces)// Module
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (!EquipmentArray[i].IsFull)
                    {
                        EquipmentArray[i] = item;
                        EquipmentArray[i].IsFull = true;
                        isSucces = true;
                        break;
                    }
                    else if (i == 3)
                    {
                        for (int j = 1; j <= 3; j++)
                        {
                            if (EquipmentArray[j].Item.AttackPower < item.Item.AttackPower)
                            {
                                mediator.SendItem(EquipmentArray[j], this);
                                EquipmentArray[j] = item;
                                EquipmentArray[j].IsFull = true;
                                isSucces = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (((int)item.Item.ItemType ^ 2) == 0 && !isSucces)// Shield
            {
                for (int i = 4; i <= 9; i++)
                {
                    if (!EquipmentArray[i].IsFull)
                    {
                        EquipmentArray[i] = item;
                        EquipmentArray[i].IsFull = true;
                        isSucces = true;
                        break;
                    }
                    else if (i == 3)
                    {
                        for (int j = 4; j <= 9; j++)
                        {
                            if (EquipmentArray[j].Item.DefencePower < item.Item.DefencePower)
                            {
                                mediator.SendItem(EquipmentArray[j], this);
                                EquipmentArray[j] = item;
                                EquipmentArray[j].IsFull = true;
                                isSucces = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (!isSucces)
                mediator.SendItem(item, this);
            EquipUpdateDelegate();
        }

        public bool UseItem()
        {
            Send();
            return true;
        }

        public void LoadItem()
        {
            EquipmentArray = GameDataManager.Instance.playerdata.EquipmentArray;
            for (int i = 0; i < EquipmentArray.Length; i++)
            {
                EquipmentArray[i].Item = ItemController.Instance.GetItem(EquipmentArray[i].Item.Code);
            }
            EquipUpdateDelegate();
        }
    }
}