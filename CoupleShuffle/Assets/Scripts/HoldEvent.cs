using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HoldEvent : MonoBehaviour
{
    public bool caseTime = false;
    
    [SerializeField] private GameObject caseParent;
    [SerializeField] private GameObject player;

    private AnimationController _animationController;

    private void Awake()
    {
        _animationController = FindObjectOfType<AnimationController>();
    }


    public void Hold()
    {
          _animationController.IdleAnimation(_animationController._leftAnim,false);
         _animationController.IdleAnimation(_animationController._rightAnim,false);
         _animationController.WalkAnimation(_animationController._leftAnim,false);
         _animationController.WalkAnimation(_animationController._rightAnim,false);
        caseParent.transform.DOMoveY(caseParent.transform.position.y + 0.3f, 0.4f)
            .OnComplete(() =>
            { 
                player.transform.parent = caseParent.transform;
                caseTime = true;
            });
    }

    public void HoldEnd()
    {
        _animationController.IdleAnimation(_animationController._leftAnim,true);
        _animationController.IdleAnimation(_animationController._rightAnim,true);
    }
}
