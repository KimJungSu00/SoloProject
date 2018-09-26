using UnityEngine;
using ManagerGroup;
using System;
using System.Collections.Generic;
namespace ItemGroup
{
    public class ItemController : Singleton<ItemController>
    {
        [SerializeField]
        ItemTable itemTable;
        ItemType defaultItemType = ItemType.Default;
        Sprite defaltSprite;

        public void GetItemInfo(int itemCode, out string name, out Sprite sprite, out ItemType itemType)
        {
            itemType = defaultItemType;
            sprite = defaltSprite;
            name = "";

            for (int i = 0; i < itemTable.sheets[0].list.Count; i++)
            {
                
                if (itemTable.sheets[0].list[i].ID == itemCode)
                {
                    name = itemTable.sheets[0].list[i].Name;
                    switch (itemTable.sheets[0].list[i].Type)
                    {
                        case "Resource":
                            itemType = ItemType.Resource;
                            break;
                        case "Consume":
                            itemType = ItemType.Consume;
                            break;
                        case "Equipment":
                            itemType = ItemType.Equipment;
                            break;
                    }
                    // sprite = AssetBundleManager.Instance.LoadSprite(itemTable.sheets[0].list[i].Sprite);
                    sprite = Resources.Load<Sprite>(itemTable.sheets[0].list[i].Sprite);
                }
               
            }

        }


        void Start()
        {
            MakeItemPool();
        }
        List<Item> itemPool = new List<Item>();

        public void MakeItemPool()
        {
            for(int i = 0; i<itemTable.sheets[0].list.Count; i++)
            {
                Item item = new Item();
                item.CodeNum = itemTable.sheets[0].list[i].ID;
                item.Name = itemTable.sheets[0].list[i].Name;
                switch (itemTable.sheets[0].list[i].Type)
                {
                    case "Resource":
                        item.ItemType = ItemType.Resource;
                        break;
                    case "Consume":
                        item.ItemType = ItemType.Consume;
                        break;
                    case "Equipment":
                        item.ItemType = ItemType.Equipment;
                        break;
                }
                item.Sprite = Resources.Load<Sprite>(itemTable.sheets[0].list[i].Sprite);
                itemPool.Add(item);
            }
        }

        public Item GetItem(int itemCode)
        {
            foreach(Item item in itemPool)
            {
                if(item.CodeNum == itemCode)
                {
                    return item;
                }
            }
            return itemPool[0];
        }

    }
}
