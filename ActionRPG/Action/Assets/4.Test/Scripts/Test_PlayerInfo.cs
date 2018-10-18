using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Test
{
    public enum StatusType
    {
        HP,
        MP,
        ATK,
        DEF,
    }
    public class Test_PlayerInfo : MonoBehaviour
    {
        [SerializeField]
        Test_EquipmentData model;

        [SerializeField]
        Text[] statusTextArr;

        [SerializeField]
        Test_Status playerStatus;

        private void Start()
        {
            playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<Test_Status>();
        }
        public void StatusUpdate()
        { 
            statusTextArr[(int)StatusType.HP].text = playerStatus.HealthPoiont.ToString();
            statusTextArr[(int)StatusType.MP].text = playerStatus.ManaPoint.ToString();
            playerStatus.EquipmentSTK = model.TotalStatus[(int)StatusType.ATK];
            playerStatus.EquipmentDEF = model.TotalStatus[(int)StatusType.DEF];
            statusTextArr[(int)StatusType.ATK].text = playerStatus.TotalStrikingPower.ToString();
            statusTextArr[(int)StatusType.DEF].text = playerStatus.TotalDefensivePower.ToString();
        }

    }
}
