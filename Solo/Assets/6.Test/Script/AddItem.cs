using UnityEngine;
using UI.Presenter;
using ItemGroup;



public class AddItem : MonoBehaviour {

   // [SerializeField]
   // Inventory inventory;
    [SerializeField]
    IInventory inventory;
    public void Additem(int itemCode)
    {
        inventory.AddItem(ItemController.Instance.GetItem(itemCode));
    }

    public void Save()
    {
        GameDataManager.Instance.SaveData();
    }

    public void Load()
    {
        GameDataManager.Instance.LoadData();
    }
}
