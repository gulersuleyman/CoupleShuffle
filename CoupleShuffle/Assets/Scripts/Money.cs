using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private float timeBoundary=0.2f;
    private float currentTime;

    private GameObject movingParent;
    
    
    private MoneyMover _mover;
    private Bezier _leftBezier;
    private Bezier _rightBezier;
    private void Awake()
    {
        _mover = FindObjectOfType<MoneyMover>();
        _leftBezier = GameObject.Find("LeftBezierParent").gameObject.GetComponent<Bezier>();
        _rightBezier = GameObject.Find("RightBezierParent").gameObject.GetComponent<Bezier>();
        movingParent = GameObject.Find("MovingParent");
    }

    private void Update()
    {
        if (_mover.moveLeft && this.gameObject==_mover.leftParent.transform.GetChild(_mover.leftParent.transform.childCount-1).gameObject)
        {
            currentTime += Time.deltaTime;
            if (currentTime>timeBoundary)
            {
                StartCoroutine(MoveToRight());
                currentTime = 0;
            }  
        }
        if (_mover.moveRight && this.gameObject==_mover.rightParent.transform.GetChild(_mover.rightParent.transform.childCount-1).gameObject)
        {
            currentTime += Time.deltaTime;
            if (currentTime>timeBoundary)
            {
                StartCoroutine(MoveToLeft());
                currentTime = 0;
            }  
        }
    }

    IEnumerator MoveToRight()
    {
        bool move = false;
        if (this.gameObject==_mover.leftParent.transform.GetChild(_mover.leftParent.transform.childCount-1).gameObject
            && _mover.leftParent.transform.childCount>=2)
        {
           
           move = true;
            
        }

        if (move)
        {
            this.gameObject.transform.parent = movingParent.gameObject.transform;
            for (int i = 0; i < 100; i++)
            {
                this.gameObject.transform.position = _leftBezier.lineRenderer.GetPosition(i);
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, -i -i+18);
                yield return new WaitForSeconds(0.01f);
            }

            this.gameObject.transform.parent = _mover.rightParent.transform;
        }
        
        
        yield return new WaitForSeconds(0.2f);
    }
    IEnumerator MoveToLeft()
    {
        bool move = false;
        if (this.gameObject==_mover.rightParent.transform.GetChild(_mover.rightParent.transform.childCount-1).gameObject
            && _mover.rightParent.transform.childCount>=2)
        {
           
            move = true;
            
        }

        if (move)
        {
            this.gameObject.transform.parent = movingParent.gameObject.transform;
            for (int i = 0; i < 100; i++)
            {
                this.gameObject.transform.position = _rightBezier.lineRenderer.GetPosition(i);
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, +i +i-18);
                yield return new WaitForSeconds(0.01f);
            }

            this.gameObject.transform.parent = _mover.leftParent.transform;
        }
        
        yield return new WaitForSeconds(0.2f);
    }

}
