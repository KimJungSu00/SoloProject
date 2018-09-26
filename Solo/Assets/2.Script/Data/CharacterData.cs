using System.Collections.Generic;
using System;
using UI.Presenter;
using Data;

[Serializable]
public class CharacterData
{
    public string CharacterName;
    public int Level;
    public int Gold;
    public List<InventoryStruct> ItemList = new List<InventoryStruct>();
    public List<Slot> EquipList;
    public List<Slot> SkillList;
}
