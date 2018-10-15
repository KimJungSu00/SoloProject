using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Test_Slot : MonoBehaviour , IBeginDragHandler, IDragHandler, IDropHandler {

    GameObject DragItemObject;
    DragItem drag;

    public Test_Slot slot;
    public Transform item;

    private void Start()
    {
        DragItemObject = GameObject.FindGameObjectWithTag("DragItem");
        drag = DragItemObject.GetComponent<DragItem>();
        
        
        slot = this;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        drag.preSlot = gameObject;
        transform.GetChild(0).SetParent(DragItemObject.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            DragItemObject.transform.position = Input.mousePosition;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        gameObject.transform.GetChild(0).SetParent(drag.preSlot.transform);
        DragItemObject.transform.GetChild(0).SetParent(gameObject.transform);
        
    }

    

   
}
