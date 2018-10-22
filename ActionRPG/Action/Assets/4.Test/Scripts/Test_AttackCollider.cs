using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    class Test_AttackCollider : MonoBehaviour
    {
        [SerializeField]
        Test_Status gameObjectStatus;
        Collider attackCollider;
        private void Start()
        {
            gameObjectStatus = GetComponentInParent<Test_Status>();
            attackCollider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            Test_Status Enemy = other.GetComponentInParent<Test_Status>();
            Enemy.HealthPoiont -= gameObjectStatus.TotalStrikingPower;
            attackCollider.enabled = false;
        }

        
    }
}