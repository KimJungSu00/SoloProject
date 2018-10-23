using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Model
{
    public class ItemMediator : MonoBehaviour
    {
        List<IItemExchangeable> windowList = new List<IItemExchangeable>();

        private void Start()
        {
            windowList.Add(GameObject.FindGameObjectWithTag("InventoryData").GetComponent<InventoryModel>());
            windowList.Add(GameObject.FindGameObjectWithTag("EquipmentData").GetComponent<EquipmentModel>());
        }

        public void SendItem(ItemStruct item, IItemExchangeable sender)
        {
            foreach(IItemExchangeable window in windowList)
            {
                if(window != sender)
                {
                    window.Receive(item);
                }
            }
        }

    }
}