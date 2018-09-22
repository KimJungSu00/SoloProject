using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Data;


namespace ManagerGroup
{
    public class JsonManager : Singleton<JsonManager>
    {
        string path;//= Application.dataPath + "/Json";
        
        private void Start()
        {
            path = Application.dataPath + "/Json";

           
        }
       
        
        public InventoryData inven;

        public void OnClickSaveJSONBtn()
        {
            List<Data> testlist = new List<Data>();
            testlist.Add(new Data(0, "이름1", 1000));
            string test = JsonUtility.ToJson(testlist, prettyPrint: true);
            Debug.Log(test);

            using (StreamWriter file =
                  new StreamWriter(this.path+"1.json", false))
            {
                file.WriteLine(test);
            }
        }

        public void OnClickLoadJSONBtn()
        {
            string load = ReadStringFromFile("JsonFile.json");
            var loadData = JsonUtility.FromJson<Data>(load);
            Debug.Log(loadData);
        }

        string ReadStringFromFile(string path)
        {
            string text = System.IO.File.ReadAllText(path + "/" + path);

            return text;
        }

        void WriteStringToFile(string text, string path)
        {
            // 에셋 번들을 저장할 경로의 폴더가 존재하지 않는다면 생성시킨다.
            if (!Directory.Exists(this.path))
            {
                Directory.CreateDirectory(this.path);
            }

            using (StreamWriter file =
                 new StreamWriter(this.path + "/" + path, false))
            {
                file.WriteLine(text);
            }

        }

        [SerializeField]
        public class Data
        {
            public int ID;
            public string Name;
            public double Gold;

            public Data(int id, string name, double gold)
            {
                ID = id;
                Name = name;
                Gold = gold;
            }
        }

    }

}