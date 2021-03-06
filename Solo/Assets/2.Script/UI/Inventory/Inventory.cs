﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
/*
namespace UI.Presenter
{

   
   public class Inventory : MonoBehaviour
   {
       public Slot SelectSlot;
       List<Slot> slotList = new List<Slot>();
       public List<Slot> SlotList { get { return slotList; } }
       [SerializeField]
       int rowCount;
       [SerializeField]
       GridLayoutGroup gridRayoutGroup;

       [SerializeField]
       GameObject slotObject;

       [SerializeField]
       private int slotHaveMaxItemCount;
       public int SlotHaveMaxItemCount { get { return slotHaveMaxItemCount; } }

       [SerializeField]
       GameObject dragItem;

       Sprite defalutSprite;

       [SerializeField]
       Text goldCountText;
       int goldCount;

       private void Start()
       {
           Initialzie();
       }

       bool Initialzie()
       {
           gridRayoutGroup.enabled = true;
           defalutSprite = Resources.Load<Sprite>("Default");
           StartCoroutine(MakeInventorySlot());         
           return true;
       }

       public bool AddItem(ItemGroup.Item item)
       {

           foreach(Slot slot in slotList)
           {
               if (slot.Additem(item))
                   return true;
           }
           return false;
       }

       IEnumerator MakeInventorySlot()
       {
           rowCount *= 7;

           for (int i = 0; i < rowCount; i++)
           {
               slotList.Add(Instantiate(slotObject).GetComponent<Slot>());
               slotList[i].transform.SetParent(transform, false);
               slotList[i].name = "Slot ["+ i +"]";
               slotList[i].Initialze(this,slotHaveMaxItemCount, defalutSprite); 
           }
           yield return new WaitForEndOfFrame();
           gridRayoutGroup.enabled = false;
           dragItem.SetActive(false);
       }

       public Slot FindNearSlot(Slot selectSlot,  Vector3 pos)
       {/*
           float min = 9999;
           Slot slot = selectSlot;
           foreach (Slot slots in slotList)
           {
               Vector2 sPos = slots.transform.position;
               float dis = Vector2.Distance(sPos, pos);
               if(dis<min)
               {
                   min = dis;
                   slot = slots;
               }
           }
           return SelectSlot;
       }

       public void SaveInventory()
       {
           CharacterData datas = new CharacterData();

           InventoryStruct[] invenData = new InventoryStruct[SlotList.Count];
           int j = 0;
           for (int i = 0; i < SlotList.Count; i++)
           {
               if (SlotList[i].ItemCode != 0)
               {
                   invenData[j] = new InventoryStruct();
                   invenData[j].index = i;
                   invenData[j].itemCode = SlotList[i].ItemCode;
                   invenData[j].itemCount = SlotList[i].ItemCount;
                   datas.ItemList.Add(invenData[j]);
                   j++;
               }
           }

           string toJson = JsonUtility.ToJson(datas, prettyPrint: true);
           using (StreamWriter file = new StreamWriter(Application.dataPath + "/Json/InvenData4.Json", false))
           {
               file.WriteLine(toJson);
               Debug.Log(toJson);
           }
       }
       public void LoadInventoryData()
       {
           string load = File.ReadAllText(Application.dataPath + "/Json/InvenData3.Json");

           var loadData = JsonUtility.FromJson<CharacterData>(load);


           foreach (var item in loadData.ItemList)
           {
               SlotList[item.index].LoadSlot(item.itemCode, item.itemCount);
           }

       }


       public void ChangeGold(int count)
       {
           goldCount += count;
           goldCountText.text = goldCount.ToString();
       }

       public void SortSlot()
       {
           QuickSort(slotList, 0, slotList.Count-1);
       }

       void QuickSort(List<Slot> slotList,int start,int end)
       {
           int pivot = 0;
           if(start<end)
           {
               pivot = PartitionQuciSort(slotList, start, end);
               QuickSort(slotList, start, pivot - 1);
               QuickSort(slotList, pivot + 1, end);
           }
       }

       int PartitionQuciSort(List<Slot> slotList, int start, int end)
       {
           int pivot = end;
           int right = end;
           int left = start;

           while(left<right)
           {
               while((slotList[left].ItemCode >= slotList[pivot].ItemCode) && (left <right))
               {
                   left++;
               }
               while ((slotList[right].ItemCode < slotList[pivot].ItemCode) && (left < right))
               {
                   right--;
               }
               if(left<right)
               {
                   slotList[left].SlotSwap(slotList[left], slotList[right]);
               }
           }
           slotList[right].SlotSwap(slotList[pivot], slotList[right]);

           return right;
       }

   }

}*/
