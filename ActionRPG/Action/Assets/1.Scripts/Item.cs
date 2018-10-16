using UnityEngine;

namespace ItemGroup
{
    public enum ItemType
    {
        Default,
        Resource,
        Consume,
        Weapon,
        Module,
        Shield,
    }

    public class Item
    {
        public int Code;
        public string Name; 
        public ItemType ItemType;
        public int ItemMaxCount;
        public Sprite Sprite;
        public int HP;
        public int MP;
        public int AttackPower;
        public int DefencePower;

        public Item()
        {
            Code = 0;
            Name = "Default";
            ItemType = ItemType.Default;
            Sprite = null;
        }
    }

}