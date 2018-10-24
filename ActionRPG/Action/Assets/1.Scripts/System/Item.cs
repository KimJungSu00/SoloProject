using UnityEngine;
using System;
namespace ItemGroup
{
   

    public enum ItemType
    {
        Default = 64,
        Resource = 32,
        Consume = 16,
        Weapon = 8,
        Module = 4,
        Shield = 2,
    }
    [Serializable]
    public class Item
    {
        public int Code;
        [NonSerialized]
        public string Name;
        [NonSerialized]
        public ItemType ItemType;
        [NonSerialized]
        public int MaxCount;
        [NonSerialized]
        public Sprite Sprite;
        [NonSerialized]
        public int HP;
        [NonSerialized]
        public int MP;
        [NonSerialized]
        public int AttackPower;
        [NonSerialized]
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