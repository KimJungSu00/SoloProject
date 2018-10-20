using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Test
{
    public class Test_StateHit : Test_MonsterState
    {
        Animator animator;

        public Test_StateHit(Animator animator)
        {
            this.animator = animator;
        }
        public void Do()
        {
          
        }

        public void Enter()
        {
            animator.SetTrigger("Hit");
        }

        public void Exit()
        {
            
        }
    }
}
