using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator _leftAnim;

    public Animator _rightAnim;

    private void Awake()
    {
        _leftAnim = GameObject.Find("CharLeft").gameObject.GetComponent<Animator>();
        _rightAnim = GameObject.Find("CharRight").gameObject.GetComponent<Animator>();
        _leftAnim.enabled = false;
        _rightAnim.enabled = false;
    }
    public void WalkAnimation(Animator _animator,bool isWalking)
    {
        if (isWalking == _animator.GetBool("isWalking")) return;

        _animator.SetBool("isWalking", isWalking);
    }
    public void IdleAnimation(Animator _animator,bool isIdle)
    {
        if (isIdle == _animator.GetBool("isIdle")) return;

        _animator.SetBool("isIdle", isIdle);
    }
    public void BendAnimation(Animator _animator,bool isBending)
    {
        if (isBending == _animator.GetBool("isBending")) return;

        _animator.SetBool("isBending", isBending);
    }
}
