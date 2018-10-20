using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Test_StateDie : Test_MonsterState
    {
        Animator animator;
        public Test_StateDie(Animator animator)
        {
            this.animator = animator;
        }

        public void Do()
        {
            animator.SetTrigger("isDead");
        }

        public void Enter()
        {
           
        }

        public void Exit()
        {
           
        }
    }
}