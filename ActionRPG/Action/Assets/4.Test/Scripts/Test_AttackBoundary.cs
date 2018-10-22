using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Test_AttackBoundary : MonoBehaviour
    {
        [SerializeField]
        StateMachin STM;

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player")
                STM.ChangeState(MonsterState.Attack);
        }

    }
}