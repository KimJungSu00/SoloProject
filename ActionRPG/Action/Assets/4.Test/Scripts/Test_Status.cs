using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Test_Status : MonoBehaviour
    {

        public int HealthPoiont;
        public int ManaPoint;
        [SerializeField]
        int strikingPower;
        [SerializeField]
        int defensivePower;
  
        public int TotalStrikingPower { get { return strikingPower + EquipmentSTK; } private set { } }
        public int TotalDefensivePower { get { return defensivePower + EquipmentDEF;  } private set { } }
        [HideInInspector]
        public int EquipmentSTK;
        [HideInInspector]
        public int EquipmentDEF;


       
    }
}
