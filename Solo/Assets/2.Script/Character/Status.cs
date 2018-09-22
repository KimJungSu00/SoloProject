using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Status : MonoBehaviour
{

    [Header("1차 능력치")]
    [ReadOnly, SerializeField, Tooltip("HP : 생명력")]
    private int healthPoint;
    [ReadOnly, SerializeField, Tooltip("SP : 스태미너")]
    private float staminaPoint;
    [ReadOnly, SerializeField, Tooltip("STR : 공격력")]
    private int strikingPower;
    [ReadOnly, SerializeField, Tooltip("DEF : 방어력")]
    private int defensivePower;
    [Space]

    [Header("2차 능력치")]
    [Tooltip("STR(힘) : 공격력, HP")]
    public int Strength;
    [Tooltip("AGL(민첩) : 이동속도, Stamina")]
    public int Agility;
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

    //Animator State

    [HideInInspector]
    public bool isWalk;
    [HideInInspector]
    public bool isAttack;
    [HideInInspector]
    public bool isRun;
    private void Start()
    {
        UpdateRawState();
    }

    public void UpdateRawState()
    {
        healthPoint = Strength * 10;
        staminaPoint = Agility * 10;
        strikingPower = Strength + AttackDamage;
        defensivePower = Will + Armor;
    }
}
