using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemGroup;
using UI.Model;

public class Test_AddItem : MonoBehaviour {

    public InventoryModel model;

    public void AddItem(int Code)
    {
        model.AddItem(ItemController.Instance.GetItem(Code));
    }

    public void Send()
    {
        model.Send();
    }
}
