using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Test_Slot : MonoBehaviour , IBeginDragHandler, IDragHandler, IDropHandler {

    public GameObject DragItem;
    public Test_Slot slot;
    public Transform item;
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.GetChild(0).SetParent(DragItem.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            DragItem.transform.position = Input.mousePosition;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        DragItem.transform.GetChild(0).SetParent(gameObject.transform,false);
    }

    

   
}
