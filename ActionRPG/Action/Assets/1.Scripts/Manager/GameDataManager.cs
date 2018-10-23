using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Model;
using System;
using System.IO;
using ItemGroup;

namespace Manager
{
    [Serializable]
    public class SaveData
    {
        public ItemStruct[] InventoryArray;
        public ItemStruct[] EquipmentArray;
    }

    public delegate void LoadDataDelegate();
    public class GameDataManager : Singleton<GameDataManager>
    {
        public SaveData playerdata = new SaveData();

        InventoryModel invenModel;
        EquipmentModel equipModel;

        public LoadDataDelegate loadCallback;
        private void Start()
        {
            invenModel = GameObject.FindGameObjectWithTag("InventoryData").GetComponent<InventoryModel>();
            equipModel = GameObject.FindGameObjectWithTag("EquipmentData").GetComponent<EquipmentModel>();
        }

        public void Save()
        {
            playerdata.InventoryArray = invenModel.ItemArray;
            playerdata.EquipmentArray = equipModel.EquipmentArray;
            string toJson = JsonUtility.ToJson(playerdata, prettyPrint: true);
            using (StreamWriter file = new StreamWriter(Application.dataPath + "/Json/PlayerData.Json", false))
            {
                file.WriteLine(toJson);
            }

        }

        public void Load()
        {
            string loadData = File.ReadAllText(Application.dataPath + "/Json/PlayerData.Json");

            var fromJson = JsonUtility.FromJson<SaveData>(loadData);
            playerdata.InventoryArray = fromJson.InventoryArray;
            playerdata.EquipmentArray = fromJson.EquipmentArray;
            loadCallback();
        }

    }
}