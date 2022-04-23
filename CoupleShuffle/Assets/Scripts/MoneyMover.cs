using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoneyMover : MonoBehaviour
{
    public GameObject moneyPrefab;
    public GameObject leftParent;
    public GameObject rightParent;

    public float lastDirectionIndex;
    
    public bool moveLeft;
    public bool moveRight;

    private float firstPosition;
    private float currentPosition;
   
    private DynamicJoystick _joystick;
    private AnimationController _animController;
    
    private void Awake()
    {
        _joystick = FindObjectOfType<DynamicJoystick>();
        _animController = FindObjectOfType<AnimationController>();
        
    }

    private void Update()
    {
        #region  joystick mover

      /*  if (Input.GetMouseButton(0))
        {
            if (_joystick.Horizontal > 0)
            {
                moveLeft = true;
                lastDirectionIndex = 1;
            }
            else
            {
                moveLeft = false;
            }

            if (_joystick.Horizontal < 0)
            {
                lastDirectionIndex = 2;
                moveRight = true;
            }
            else
            {
                moveRight = false;
            }
            
        }*/

        #endregion

        if (!GameManager.Instance.endSwipe)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _animController._leftAnim.enabled = true;
                _animController._rightAnim.enabled = true;
                GameManager.Instance.began = true;
                firstPosition = Input.mousePosition.x;
            }
            if (Input.GetMouseButton(0))
            {
                currentPosition = Input.mousePosition.x;
                float distance = currentPosition - firstPosition;
                if (distance>0)
                {
                    moveLeft = true;
                    lastDirectionIndex = 1;
                }
                else
                {
                    moveLeft = false;
                }

                if (distance<0)
                {
                    lastDirectionIndex = 2;
                    moveRight = true;
                }
                else
                {
                    moveRight = false;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                moveLeft = false;
                moveRight = false;
            }
        }
        
    }

}
