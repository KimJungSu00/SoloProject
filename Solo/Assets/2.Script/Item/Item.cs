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

    public class Item : MonoBehaviour
    {
        ItemController itemCotroller;
        
        public int CodeNum;
        string name;
        public string Name { get { return name; }}
        ItemType itemType;
        public ItemType ItemType { get { return itemType; }}
        Sprite sprite;
        public Sprite Sprite { get { return sprite; } }
        private void Start()
        {
            itemCotroller = GameObject.FindGameObjectWithTag("ItemController").GetComponent<ItemController>();
            itemCotroller.GetItemInfo(CodeNum,out name,out sprite,out itemType);
        }

    }

}