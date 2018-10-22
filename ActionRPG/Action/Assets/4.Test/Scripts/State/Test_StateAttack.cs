using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Test_StateAttack : Test_MonsterState
    {
        GameObject target;
        float distanceToPlayer = 5;
        float attackDelay = 2;
        GameObject gameObject;
        Animator animator;
        

        public Test_StateAttack(Animator animator, GameObject gameObject)
        {
            this.animator = animator;
            this.gameObject = gameObject;
        }

        public void Enter()
        {
            animator.SetTrigger("Attack");
        }

        public void Do()
        {
            
        }


        public void Exit()
        {
            
        }
    }
}