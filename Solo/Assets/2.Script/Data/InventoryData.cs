using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Presenter;
using System;
using ManagerGroup;
using System.IO;
namespace Data
{
    [Serializable]
    public class InventoryStruct
    {
        public int index;
        public int itemCode;
        public int itemCount;
    }
    public class InventoryData : MonoBehaviour
    {
        [SerializeField]
        public InventoryStruct[] invenData;
        // public Dictionary<int, InventoryStruct> invenData;
        Inventory inventory;

        private void Start()
        {
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
            invenData = new InventoryStruct[inventory.SlotList.Count];
            // invenData = new Dictionary<int, InventoryStruct>();
        }

        public void AddItem(ItemGroup.Item item)
        {
            inventory.AddItem(item);
        }
        
        public void SaveInventoryData()
        {
            /*
              int j = 0;
              invenData = new InventoryStruct[inventory.SlotList.Count];
              for (int i = 0; i < inventory.SlotList.Count; i++)
              {
                  if (inventory.SlotList[i].ItemCode != 0)
                  {
                      invenData[j] = new InventoryStruct();
                      invenData[j].index = i;
                      invenData[j].itemCode = inventory.SlotList[i].ItemCode;
                      invenData[j].itemCount = inventory.SlotList[i].ItemCount;

                      j++;
                  }
              }
            
            string toJson = JsonHelper.ToJson(invenData, prettyPrint: true);
            */
            CharacterData datas = new CharacterData();
            int j = 0;
            invenData = new InventoryStruct[inventory.SlotList.Count];
            for (int i = 0; i < inventory.SlotList.Count; i++)
            {
                if (inventory.SlotList[i].ItemCode != 0)
                {
                    invenData[j] = new InventoryStruct();
                    invenData[j].index = i;
                    invenData[j].itemCode = inventory.SlotList[i].ItemCode;
                    invenData[j].itemCount = inventory.SlotList[i].ItemCount;
                    datas.ItemList.Add(invenData[j]);
                    j++;
                }
            }

            string toJson = JsonUtility.ToJson(datas, prettyPrint: true);
           // string toJson = JsonHelper.ToJson(invenData, prettyPrint: true);
            using (StreamWriter file = new StreamWriter(Application.dataPath + "/Json/InvenData2.Json", false))
            {
                file.WriteLine(toJson);
                Debug.Log(toJson);
            }
        }

        public void LoadInventoryData()
        {
            string load = File.ReadAllText(Application.dataPath + "/Json/InvenData2.Json");
            /*var loadData = JsonHelper.FromJson<InventoryStruct>(load);
            
            foreach (var loadItem in loadData)
            {
                if (loadItem.itemCount == 0)
                    continue;
                inventory.SlotList[loadItem.index].LoadSlot(loadItem.itemCode, loadItem.itemCount);
            }*/
            var loadData = JsonUtility.FromJson<CharacterData>(load);

            foreach(var item in loadData.ItemList)
            {
                inventory.SlotList[item.index].LoadSlot(item.itemCode, item.itemCount);
            }

        }
    }

}