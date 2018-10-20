using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Test_StateMove : Test_MonsterState
    {
        
        Rigidbody rigidbody;
        GameObject target;
        GameObject gameObject;
        float moveSpeed;
        Vector3 direction;
        Animator animator;
        public Test_StateMove(Rigidbody rigidbody, GameObject gameObject,float speed,Animator animator)
        {
            this.rigidbody = rigidbody;
            this.gameObject = gameObject;
            moveSpeed = speed;
            this.animator = animator;
        }
        public void Enter()
        {
            target = GameObject.FindGameObjectWithTag("Player");
            animator.SetFloat("Speed", 1);
        }

        public void Do()
        {
            Move();
            Turn();
        }

        public void Move()
        {
            direction = Vector3.Normalize(target.transform.position - gameObject.transform.position);
            rigidbody.velocity = direction * moveSpeed * Time.deltaTime;
        }

        public void Turn()
        {
            if (direction == Vector3.zero)
                return;
            if (direction.z < 0)
            {
                rigidbody.rotation = Quaternion.Euler(new Vector3(0, 180));
            }
            else
            {
                rigidbody.rotation = Quaternion.Euler(new Vector3(0, 0));
            }
        }
        public void Exit()
        {
            animator.SetFloat("Speed", 0);
            Debug.Log("이동 종료");
        }
    }
}
