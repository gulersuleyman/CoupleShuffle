using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG.Tweening;
public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] GameObject caseParent;
    
    
    public bool caseTime = false;

    private CinemachineVirtualCamera _vcam;
    private AnimationController _animationController;
    private JoyStickRotator _joyStickRotator;
    private void Awake()
    {
        _animationController = GetComponent<AnimationController>();
        _vcam = FindObjectOfType<CinemachineVirtualCamera>();
        _joyStickRotator = FindObjectOfType<JoyStickRotator>();
        _joyStickRotator.Working = false;
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
                _animationController.WalkAnimation(_animationController._leftAnim,true);
                _animationController.WalkAnimation(_animationController._rightAnim,true);

                transform.DOMove(caseParent.transform.position, 2f).OnComplete(() =>
                {
                    transform.parent = caseParent.transform;
                    _joyStickRotator.Working = true;
                });

            });
        }
    }

    
}
