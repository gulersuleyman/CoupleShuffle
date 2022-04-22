using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoneyMover : MonoBehaviour
{
    
    public GameObject leftParent;
    public GameObject rightParent;

    public float lastDirectionIndex;
    
    public bool moveLeft;
    public bool moveRight;

    private float firstPosition;
    private float currentPosition;
   
    private DynamicJoystick _joystick;
    
    private void Awake()
    {
        _joystick = FindObjectOfType<DynamicJoystick>();
        
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

        if (Input.GetMouseButtonDown(0))
        {
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
