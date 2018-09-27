using UnityEngine;

namespace ItemGroup
{
    public enum ItemType
    {
        Default,
        Resource,
        Consume,
        Equipment,
    }

    public class Item
    {
        public int CodeNum;
        public string Name; 
        public ItemType ItemType;
        public int ItemMaxCount;
        public Sprite Sprite;
        public Item()
        {
            CodeNum = 0;
            Name = "Default";
            ItemType = ItemType.Default;
            Sprite = null;
        }
    }

}