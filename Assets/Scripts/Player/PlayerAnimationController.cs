using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerAnimationController : AnimationController
{
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Die = Animator.StringToHash("Die");
    
    private void OnEnable()
    {
        controller.OnJump -= Jumping;
        controller.OnJump += Jumping;
        GameManager.Instance.OnGameOver -= Death;
        GameManager.Instance.OnGameOver += Death;
    }
    
    private void Jumping()
    {
        animator.SetTrigger(Jump);
    }
    
    private void Death()
    {
        animator.SetTrigger(Die);
        StartCoroutine(WaitForDeathAnim());
    }

    private IEnumerator WaitForDeathAnim()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0.0f;
    }
}