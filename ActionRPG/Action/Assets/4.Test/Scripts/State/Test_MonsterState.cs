using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public interface Test_MonsterState
    {
        void Enter();
        void Do();
        void Exit();
    }
}
