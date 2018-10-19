using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public enum MonsterState
    {
        Idle,
        Patrol,
        Chasing,
        Attack,
        Hit,
        Death,

    }
    public class StateMachin : MonoBehaviour
    {
        Rigidbody rigidbody;

        public Test_MonsterState state;
        public GameObject Taget;
        MonsterState curruntState;

        public  Animator animator;
        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            state = new Test_StateIdle();
        }

        private void Update()
        {
            if (state != null)
                state.Update();
        }
        void ChangeState(MonsterState newState)
        {
            if (curruntState == newState)
                return;
            if (state != null)
                state.Exit();

            switch (newState)
            {

                case MonsterState.Patrol:
                    break;
                case MonsterState.Chasing:
                    state = new Test_StateMove(rigidbody, gameObject, 250f, animator);
                    break;
                case MonsterState.Attack:
                    break;
                case MonsterState.Hit:
                    break;
                case MonsterState.Death:
                    break;
                default:
                    state = new Test_StateIdle();
                    break;
            }
            state.Enter();
            curruntState = newState;
        }

        public void TestChangeState()
        {
            ChangeState(MonsterState.Chasing);
        }
    }
}