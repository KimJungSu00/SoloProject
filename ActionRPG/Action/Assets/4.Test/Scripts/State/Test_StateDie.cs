using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Test_StateDie : Test_MonsterState
    {
        Animator animator;
        GameObject gameObject;

        float Timer = 0;
        float intervalTime = 3.0f;
        public Test_StateDie(Animator animator,GameObject gameObject)
        {
            this.animator = animator;
            this.gameObject = gameObject;
        }

        public void Enter()
        {
            animator.SetTrigger("isDead");
        }
        public void Do()
        {
            Timer += Time.deltaTime;
            if (Timer >= intervalTime)
            {
                Debug.Log(Timer);
                DestroyMe.Destroy(gameObject);
            }
        }

       

        public void Exit()
        {
           
        }

        
    }
}