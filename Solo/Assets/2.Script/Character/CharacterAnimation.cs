using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    Animator animator;
    Status state;
    bool isWalk;
    bool isAttack;
    bool isRun;
    bool isJump;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        state = GetComponent<Status>();
       
	}
	
	// Update is called once per frame
	void Update () {
        PlayWalkAnimation();
        PlayAttackAnimation();
        PlayRunAnimation();
        PlayerJumpAnimation();
    }

    void PlayWalkAnimation()
    {
        if(isWalk !=state.isWalk)
        {
            isWalk = state.isWalk;
            animator.SetBool("isWalk", isWalk);
        }
    }
    void PlayRunAnimation()
    {
        if (isRun != state.isRun)
        {
            isRun = state.isRun;
            animator.SetBool("isRun", isRun);
        }
    }

    void PlayAttackAnimation()
    {
        if (isAttack != state.isAttack)
        {
            isAttack = state.isAttack;
            animator.SetBool("isAttack", isAttack);
        }
    }
    void PlayerJumpAnimation()
    {
        if(PlayerInputManager.Instance.JumpButton())
        { 
             animator.SetTrigger("isJump");
        }
    }

}
