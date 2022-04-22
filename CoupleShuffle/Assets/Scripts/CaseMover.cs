using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseMover : MonoBehaviour
{
    private HoldEvent _event;
    private AnimationController _animationController;
    private void Awake()
    {
        _event = FindObjectOfType<HoldEvent>();
        _animationController=FindObjectOfType<AnimationController>();
    }

    private void Update()
    {
        if (_event.caseTime)
        {
            if (Input.GetMouseButton(0))
            {
                transform.Translate(Vector3.forward*Time.deltaTime*3);
                _animationController.HoldWalkAnimation(_animationController._leftAnim,true);
                _animationController.HoldWalkAnimation(_animationController._rightAnim,true);
            }
            else
            {
                _animationController.HoldWalkAnimation(_animationController._leftAnim,false);
                _animationController.HoldWalkAnimation(_animationController._rightAnim,false);
            }
        }
    }
}
