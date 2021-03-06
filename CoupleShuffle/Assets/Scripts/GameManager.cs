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
        if (leftScore<=0)
        {
            leftScore = 0;
        }
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
        if (rightScore<=0)
        {
            rightScore = 0;
        }
        OnRightScoreChanged?.Invoke(rightScore);
    }

    public IEnumerator SpendMoney()
    {
        int score = totalScore;
        for (int i = 0; i < score; i++)
        {
            totalScore--;
            Debug.Log(totalScore);
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;

    }
}
