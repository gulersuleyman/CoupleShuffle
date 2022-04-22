using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] GameObject caseParent;
    
    public bool caseTime = false;


    private AnimationController _animationController;

    private void Awake()
    {
        _animationController = GetComponent<AnimationController>();
    }

    void Update()
    {
        if (!caseTime && GameManager.Instance.began)
        {
            transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Case"))
        {
            caseTime = true;
            GameManager.Instance.endSwipe = true;
            _animationController.IdleAnimation(_animationController._leftAnim,true);
            _animationController.IdleAnimation(_animationController._rightAnim,true);

            MoveMoniesToCase();
        }
    }

    void MoveMoniesToCase()
    {
        Money[] monies = FindObjectsOfType<Money>();
        foreach (Money m in monies)
        {
            m.gameObject.transform.DOMove(caseParent.transform.position, 1f);
            m.gameObject.transform.DOScale(Vector3.zero, 1.1f).OnComplete(() =>
            {
                m.gameObject.transform.parent = caseParent.transform.GetChild(0).gameObject.transform;
                m.gameObject.SetActive(false);
            });
        }
    }
}
