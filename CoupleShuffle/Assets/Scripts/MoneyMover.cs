using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoneyMover : MonoBehaviour
{
    
    public GameObject leftParent;
    public GameObject rightParent;

    
    public bool moveLeft;
    public bool moveRight;

   
    private DynamicJoystick _joystick;
    private Bezier _leftBezier;
    private Bezier _rightBezier;
    private void Awake()
    {
        _joystick = FindObjectOfType<DynamicJoystick>();
        
    }

    private void Update()
    {
        _leftBezier = GameObject.Find("LeftBezierParent").gameObject.GetComponent<Bezier>();
        _rightBezier = GameObject.Find("RightBezierParent").gameObject.GetComponent<Bezier>();
        
        
        if (Input.GetMouseButton(0))
        {
            if (_joystick.Horizontal > 0)
            {
                moveLeft = true;
                
            }
            else
            {
                moveLeft = false;
            }

            if (_joystick.Horizontal < 0)
            {
                Debug.Log(_joystick.Horizontal);
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
