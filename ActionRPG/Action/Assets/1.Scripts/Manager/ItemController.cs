﻿using UnityEngine;
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

        [SerializeField]
        int resourceItemCount = 99;
        [SerializeField]
        int consumeItemCount = 10;
       
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
                        case "Module":
                            itemType = ItemType.Module;
                            break;
                        case "Weapon":
                            itemType = ItemType.Weapon;
                            break;
                        case "Shield":
                            itemType = ItemType.Shield;
                            break;
                    }
                    // sprite = AssetBundleManager.Instance.LoadSprite(itemTable.sheets[0].list[i].Sprite);
                    sprite = Resources.Load<Sprite>(itemTable.sheets[0].list[i].Sprite);
                }
               
            }

        }


        void Awake()
        {
            MakeItemPool();
        }
        
        public List<Item> itemPool = new List<Item>();

        public void MakeItemPool()
        {
            for(int i = 0; i<itemTable.sheets[0].list.Count; i++)
            {
                Item item = new Item();
                item.Code = itemTable.sheets[0].list[i].ID;
                item.Name = itemTable.sheets[0].list[i].Name;
                item.MaxCount = 1;
                switch (itemTable.sheets[0].list[i].Type)
                {
                    case "Resource":
                        item.ItemType = ItemType.Resource;
                        item.MaxCount = resourceItemCount;
                        break;
                    case "Consume":
                        item.ItemType = ItemType.Consume;
                        item.MaxCount = consumeItemCount;
                        break;
                    case "Module":
                        item.ItemType = ItemType.Module;
                        break;
                    case "Weapon":
                        item.ItemType = ItemType.Weapon;
                        break;
                    case "Shield":
                        item.ItemType = ItemType.Shield;
                        break;

                }
                item.HP = itemTable.sheets[0].list[i].HP;
                item.MP = itemTable.sheets[0].list[i].MP;
                item.AttackPower = itemTable.sheets[0].list[i].ATD;
                item.DefencePower = itemTable.sheets[0].list[i].DEF;
                item.Sprite = Resources.Load<Sprite>(itemTable.sheets[0].list[i].Sprite);

                itemPool.Add(item);
            }
        }

        public Item GetItem(int itemCode)
        {
            foreach(Item item in itemPool)
            {
                if(item.Code == itemCode)
                {
                    return item;
                }
            }
            return itemPool[0];
        }

    }
}
