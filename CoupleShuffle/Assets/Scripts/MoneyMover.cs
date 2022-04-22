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

   
    private DynamicJoystick _joystick;
    
    private void Awake()
    {
        _joystick = FindObjectOfType<DynamicJoystick>();
        
    }

    private void Update()
    {
        
        if (Input.GetMouseButton(0))
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
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            moveLeft = false;
            moveRight = false;
        }
    }

}
