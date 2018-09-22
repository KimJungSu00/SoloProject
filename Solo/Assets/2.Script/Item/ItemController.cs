using UnityEngine;
using ManagerGroup;

namespace ItemGroup
{
    public class ItemController : MonoBehaviour
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
                    sprite = AssetBundleManager.Instance.LoadSprite(itemTable.sheets[0].list[i].Sprite);
                }
               
            }

        }

    }
}
