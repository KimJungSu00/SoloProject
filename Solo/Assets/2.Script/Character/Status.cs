using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class Status : MonoBehaviour
{

    [Header("1차 능력치")]
    [ReadOnly, SerializeField, Tooltip("HP : 생명력")]
    private int healthPoint;
    [ReadOnly, SerializeField, Tooltip("MP : 마법력")]
    private float manaPoint;
    [ReadOnly, SerializeField, Tooltip("STR : 공격력")]
    private int strikingPower;
    [ReadOnly, SerializeField, Tooltip("DEF : 방어력")]
    private int defensivePower;
    [Space]

    [Header("2차 능력치")]
    [Tooltip("STR(힘) : 공격력, HP")]
    public int Strength;
    [Tooltip("AGL(민첩) : 이동속도, Stamina")]
    public int Intelligence;
    [Tooltip("DEX(재주) : 크리티컬")]
    public int Dexterity;
    [Tooltip("Will(의지) : 방어력")]
    public int Will;
    [Tooltip("Luck(행운) : 드랍")]
    public int Luck;

    [Header("장비 추가 능력치")]
    [ReadOnly]
    public int AttackDamage;
    [ReadOnly]
    public int Armor;
    [ReadOnly]
    public int HP;
    [ReadOnly]
    public int MP;

    //Animator State

    [HideInInspector]
    public bool isWalk;
    [HideInInspector]
    public bool isAttack;
    [HideInInspector]
    public bool isRun;
    private void Start()
    {
        GameDataManager.Instance.LoadEvent += new EventHandler(LoadData);
        UpdateRawState();
    }

    public void LoadData(object sender, EventArgs e)
    {
        UpdateRawState();
    }
    public void UpdateRawState()
    {
        GameDataManager.Instance.LoadEquipmentStatus(out HP, out MP, out AttackDamage, out Armor);
        healthPoint = (Strength * 10)+ HP;
        manaPoint = (Intelligence * 10)+MP;
        strikingPower = Strength + AttackDamage;
        defensivePower = Will + Armor;
    }

   
}
