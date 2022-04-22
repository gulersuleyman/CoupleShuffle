using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class CharacterController : MonoBehaviour
{
    public Text leftText;
    public Text rightText;
    
    [SerializeField] private float moveSpeed;
    [SerializeField] GameObject caseParent;
    [SerializeField] private GameObject leftCanvas;
    [SerializeField] private GameObject rightCanvas;
    
    public bool caseTime = false;

    private int leftCount = 4;
    private int rightCount = 4;
    
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

    private void Start()
    {
        
        GameManager.Instance.OnLeftScoreChanged += HandleOnLeftScoreChanged;
        GameManager.Instance.OnRightScoreChanged += HandleOnRightScoreChanged;
        HandleOnLeftScoreChanged(1);
        HandleOnRightScoreChanged(1);
        leftText.text = leftCount.ToString();
        rightText.text = rightCount.ToString();
    }

    private void OnDisable()
    {
        GameManager.Instance.OnLeftScoreChanged -= HandleOnLeftScoreChanged;
        GameManager.Instance.OnRightScoreChanged -= HandleOnRightScoreChanged;
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
            leftCanvas.gameObject.SetActive(false);
            rightCanvas.gameObject.SetActive(false);
            MoveMoniesToCase();
            GameManager.Instance.totalScore = GameManager.Instance.rightScore + GameManager.Instance.leftScore;
            Debug.Log(GameManager.Instance.totalScore);
        }
    }

    void MoveMoniesToCase()
    {
        bool movePlayers = true;
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

                if (movePlayers)
                {
                    MoveCharsToCase();
                    movePlayers = false;
                }
                
            });
        }
        
    }

    void MoveCharsToCase()
    {
            transform.DOMove(caseParent.transform.position, 1f).OnComplete(() =>
            {
                _joyStickRotator.Working = true; 
                _animationController.BendAnimation(_animationController._leftAnim,true);
                _animationController.BendAnimation(_animationController._rightAnim,true);
                _vcam.Follow = caseParent.transform;
            });
       
    }

    public void HandleOnLeftScoreChanged(int i)
    {
        leftText.text = GameManager.Instance.leftScore.ToString();
    }
    public void HandleOnRightScoreChanged(int i)
    {
        rightText.text = GameManager.Instance.rightScore.ToString();
    }
    
}
