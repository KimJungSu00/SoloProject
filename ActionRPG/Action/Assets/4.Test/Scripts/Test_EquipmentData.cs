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
        Test_PlayerInfo playerInfoPresentere;

        [SerializeField]
        Test_GameMediator mediator;



        public int[] TotalStatus;
        
        private void Start()
        {
            TotalStatus = new int[4];
            MakeSlotData();
            equipmentPresenter.SlotUpdate();
            SetTotalStatus();
            
            playerInfoPresentere.StatusUpdate();
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
            SetTotalStatus();
            equipmentPresenter.SlotUpdate();
            playerInfoPresentere.StatusUpdate();
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
                    else
                    {
                        equipmentPresenter.Previousindex = 0;
                        SendItem();
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
                    if( i == (int)EquipType.Module && EquipmentArray[i].IsFull)
                    {
                        for(int j = (int)EquipType.Weapon + 1; j<= (int)EquipType.Module;j++)
                        {
                            if(EquipmentArray[j].Item.AttackPower< item.Item.AttackPower)
                            {
                                equipmentPresenter.Previousindex = j;
                                SendItem();
                                EquipmentArray[j] = item;
                                isSucces = true;
                                break;
                            }
                        }
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
                    if (i == (int)EquipType.Shield && EquipmentArray[i].IsFull)
                    {
                        for (int j = (int)EquipType.Module + 1; j <= (int)EquipType.Shield; j++)
                        {
                            if (EquipmentArray[j].Item.DefencePower < item.Item.DefencePower)
                            {
                                equipmentPresenter.Previousindex = j;
                                SendItem();
                                EquipmentArray[j] = item;
                                isSucces = true;
                                break;
                            }
                        }
                    }
                }

            }
            if (!isSucces)
                mediator.Send(item, this);
            SetTotalStatus();
            equipmentPresenter.SlotUpdate();
            playerInfoPresentere.StatusUpdate();
        }

        void SetTotalStatus()
        {
            TotalStatus[(int)StatusType.HP] = 0;
            TotalStatus[(int)StatusType.MP] = 0;
            TotalStatus[(int)StatusType.ATK] = 0;
            TotalStatus[(int)StatusType.DEF] = 0;
            for (int i = 0; i < EquipmentArray.Length;i++)
            {
                TotalStatus[(int)StatusType.HP] += EquipmentArray[i].Item.HP;
                TotalStatus[(int)StatusType.MP] += EquipmentArray[i].Item.MP;
                TotalStatus[(int)StatusType.ATK] += EquipmentArray[i].Item.AttackPower;
                TotalStatus[(int)StatusType.DEF] += EquipmentArray[i].Item.DefencePower;
            }
        }
    }
}