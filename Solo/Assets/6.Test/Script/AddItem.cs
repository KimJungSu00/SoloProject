using UnityEngine;
using UI.Presenter;
using ItemGroup;
using Data;


public class AddItem : MonoBehaviour {

   // [SerializeField]
   // Inventory inventory;
    [SerializeField]
    Test_Inventory inventory;
    public void Additem(int itemCode)
    {
        inventory.AddItem(ItemController.Instance.GetItem(itemCode));
    }
}
