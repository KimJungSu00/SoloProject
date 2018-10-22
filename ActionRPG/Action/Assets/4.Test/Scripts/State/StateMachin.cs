using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public enum MonsterState
    {
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

        [SerializeField]
        Collider attackCollider;
        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            state = new Test_StateIdle();
        }

        private void Update()
        {
            if (state != null)
                state.Do();
        }
        public void ChangeState(MonsterState newState)
        {
            if (curruntState == newState || curruntState == MonsterState.Death)
                return;
            if (state != null)
                state.Exit();

            switch (newState)
            {
                case MonsterState.Chasing:
                    state = new Test_StateMove(rigidbody, gameObject, 250f, animator);
                    break;
                case MonsterState.Attack:
                    attackCollider.enabled = true;
                    state = new Test_StateAttack(animator,gameObject);    
                    break;
                case MonsterState.Hit:
                    state = new Test_StateHit(animator);
                    break;
                case MonsterState.Death:
                    state = new Test_StateDie(animator,gameObject);
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
        public void TestDeath()
        {
            ChangeState(MonsterState.Death);
        }
        public void TestHit()
        {
            ChangeState(MonsterState.Hit);
        }
        public void TestAttack()
        {
            ChangeState(MonsterState.Attack);
        }

        //Animation Events
        
        public void EndAttack()
        {
            StartCoroutine(EndAttackDelay());
        }
        public void HitEnd()
        {
            ChangeState(MonsterState.Chasing);
        }

        IEnumerator EndAttackDelay()
        {
            yield return new WaitForSeconds(2.0f);
            ChangeState(MonsterState.Chasing);
        }
    }
}