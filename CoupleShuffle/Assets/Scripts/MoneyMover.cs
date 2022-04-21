using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoneyMover : MonoBehaviour
{
    public GameObject leftParent;
    public GameObject rightParent;
    
    
    private DynamicJoystick _joystick;
    private Bezier _bezier;
    
    private void Awake()
    {
        _joystick = FindObjectOfType<DynamicJoystick>();
        _bezier = FindObjectOfType<Bezier>();
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (_joystick.Horizontal > 0)
            {
                StartCoroutine(JumpToRight());
            }
            else if(_joystick.Horizontal < 0)
            {
               
            }
        }
    }

    IEnumerator StartJumpToRight()
    {
        GameObject currentObject = leftParent.transform.GetChild(leftParent.transform.childCount - 1).gameObject;
        
        for (int i = 0; i < 100; i++)
        {
            currentObject.transform.position = _bezier.lineRenderer.GetPosition(i);
            yield return new WaitForSeconds(0.001f);
        }
        
        currentObject.transform.parent = rightParent.transform;
        
        yield return null;

    }

    IEnumerator JumpToRight()
    {
        StartCoroutine(StartJumpToRight());
        yield return new WaitForSeconds(0.2f);
    }

    
}
