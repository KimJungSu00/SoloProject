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

        public Test_Slot[] slotArray;

        [SerializeField]
        Test_InventoryData model;

        Item item;
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
            for (int i = 0; i < SlotCount; i++)
            {
                slotArray[i].slotImage.sprite = model.ItemArray[i].item.Sprite;
                
                slotArray[i].CountText.text = model.ItemArray[i].itemCount.ToString();
                if (model.ItemArray[i].itemCount <= 1)
                {
                    slotArray[i].CountText.text = string.Empty;
                }
            }
        }

        public void Swap(int slotAIndex, int slotBIndex)
        {
            ItemStruct temp = model.ItemArray[slotAIndex];
            model.ItemArray[slotAIndex] = model.ItemArray[slotBIndex];
            model.ItemArray[slotBIndex] = temp;
            SlotUpdate();
        }

    }
}
