using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int leftScore=4;
    public int rightScore=4;
    public int totalScore;

    public bool began = false;
    public bool endSwipe = false;
    
    public event System.Action<int> OnLeftScoreChanged;
    public event System.Action<int> OnRightScoreChanged;
    public static GameManager Instance { get; private set; }
    
    void Awake()
    {
        rightScore = 4;
        leftScore = 4;
        SingletonThisGameObject();
    }
    public void SingletonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void IncreaseLeftScore(int i)
    {
        leftScore += i;
        OnLeftScoreChanged?.Invoke(leftScore);
    }
    public void DecreaseLeftScore(int i)
    {
        leftScore -= i;
        OnLeftScoreChanged?.Invoke(leftScore);
    }
    public void IncreaseRightScore(int i)
    {
        rightScore += i;
        OnRightScoreChanged?.Invoke(rightScore);
    }
    public void DecreaseRightScore(int i)
    {
        rightScore -= i;
        OnRightScoreChanged?.Invoke(rightScore);
    }
    
}
