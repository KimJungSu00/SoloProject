using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemGroup;
namespace Test
{
    public class Test_Inventory : MonoBehaviour
    {

        [SerializeField]
        public int SlotCount;
        [SerializeField]
        GameObject slotPrefab;

        Test_Slot[] slotArray;

        [SerializeField]
        Test_InventoryData model;

        Item item;

        public int Previousindex;
        public void Awake()
        {
            MakeSlot();
        }
        void MakeSlot()
        {
            slotArray = new Test_Slot[SlotCount];
            for (int i = 0; i < slotArray.Length; i++)
            {
                slotArray[i] = Instantiate(slotPrefab).GetComponent<Test_Slot>();
                slotArray[i].transform.SetParent(gameObject.transform);
                slotArray[i].index = i;
            }
        }
        public void Additem(int itemCode)
        {
            item = ItemController.Instance.GetItem(itemCode);
            model.AddItem(item);
            SlotUpdate();
        }

        public void SlotUpdate()
        {
            model.RemoveItem();
            for (int i = 0; i < SlotCount; i++)
            {
                slotArray[i].slotImage.sprite = model.ItemArray[i].Item.Sprite;
                slotArray[i].CountText.text = model.ItemArray[i].ItemCount.ToString();
                if (model.ItemArray[i].ItemCount <= 1)
                {
                    slotArray[i].CountText.text = string.Empty;
                }
            }
        }

        public void SwapInventory(int slotBIndex)
        {
            if (model.ItemArray[Previousindex].Item.Code == model.ItemArray[slotBIndex].Item.Code)
            {
                model.ItemArray[slotBIndex].ItemCount += model.ItemArray[Previousindex].ItemCount;
                model.ItemArray[Previousindex].ItemCount = 0;
                if (model.ItemArray[slotBIndex].ItemCount > model.ItemArray[slotBIndex].Item.MaxCount)
                {
                    model.ItemArray[Previousindex].ItemCount = model.ItemArray[slotBIndex].ItemCount % model.ItemArray[slotBIndex].Item.MaxCount;
                    model.ItemArray[slotBIndex].ItemCount = model.ItemArray[slotBIndex].Item.MaxCount;
                }
            }
            else
            {
                Swap(Previousindex, slotBIndex);
            }
            SlotUpdate();
        }


        void Swap(int slotAIndex, int slotBIndex)
        {
            ItemStruct temp = model.ItemArray[slotAIndex];
            model.ItemArray[slotAIndex] = model.ItemArray[slotBIndex];
            model.ItemArray[slotBIndex] = temp;
        }

        public void SortInventory()
        {
            if (model.Sort())
                SlotUpdate();
        }

       
    }
}
