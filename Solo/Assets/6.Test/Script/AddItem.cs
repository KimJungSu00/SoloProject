using UnityEngine;
using UI.Presenter;
using ItemGroup;
using Data;


public class AddItem : MonoBehaviour {

    [SerializeField]
    InventoryData inventory;

    [SerializeField]
    Item item;

	
    public void Additem()
    {
        inventory.AddItem(item);
    }
}
