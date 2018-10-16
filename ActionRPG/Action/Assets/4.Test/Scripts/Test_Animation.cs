using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Test_Animation : MonoBehaviour
    {

        [SerializeField]
        Animator animator;

        [SerializeField]
        Test_Character character;


        private void Update()
        {
            WalkAnimation();
            JupmAnimation();
            AttackAnimation();
        }

        void WalkAnimation()
        {
            animator.SetBool("Walk", character.IsWalk);
            animator.SetBool("Run", character.IsRun);
        }
        void JupmAnimation()
        {
            if (Test_InputManager.Instance.OnClickedJumpButton())
                animator.SetTrigger("Jump");
        }

        void AttackAnimation()
        {
            if (Test_InputManager.Instance.OnClickedAttackButton())
                animator.SetTrigger("Attack");
        }
    }
}