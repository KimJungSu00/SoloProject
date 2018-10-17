using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Test_GameMediator : MonoBehaviour
    {
        List<IGameDatable> list = new List<IGameDatable>();

        private void Start()
        {
            list.Add(GameObject.FindGameObjectWithTag("InventoryData").GetComponent<Test_InventoryData>());
            list.Add(GameObject.FindGameObjectWithTag("EquipmentData").GetComponent<Test_EquipmentData>());
        }
        public void Send(ItemStruct item, IGameDatable sender)
        {
            foreach(IGameDatable DataContainer in list)
            {
                if(DataContainer!=sender)
                {
                    DataContainer.ReceiveItem(item);
                }
            }
        }
    }
}