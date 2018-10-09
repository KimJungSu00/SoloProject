using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    Animator animator;
    PlayerController state;
    [SerializeField]
    AnimatorStateInfo test;
    

    bool isWalk;
    bool isAttack;
    bool isRun;
    bool isJump;
    bool isDeath;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        state = GetComponent<PlayerController>();
        
	}
	
	// Update is called once per frame
	void Update () {
        PlayWalkAnimation();
        PlayAttackAnimation();
        PlayRunAnimation();
        PlayerJumpAnimation();
        PlayerDeathAnimation();
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

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1")&& PlayerInputManager.Instance.AttackButton())
        {
            animator.SetTrigger("isCombo");
            return;
        }
        if (PlayerInputManager.Instance.AttackButton())
        {
            animator.SetTrigger("isAttack");
        }
    }
    void PlayerJumpAnimation()
    {
        if(PlayerInputManager.Instance.JumpButton())
        { 
             animator.SetTrigger("isJump");
        }
    }

    void PlayerDeathAnimation()
    {
        if(!state.isAlive && !isDeath)
        {
            int index = Random.Range(0, 10);
            index = index % 2;
            animator.SetTrigger("isDie" + index.ToString());
            isDeath = true;
        }
    }

   

}
