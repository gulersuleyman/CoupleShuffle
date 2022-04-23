using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Door : MonoBehaviour
{
    
    
    public Text operationText;
    private int operationNumber;
    private int operationIndex;
    private int moneyCountLeft = 0;
    private int moneyCountRight=0;
    private MoneyMover _money;
    public enum Operation
    {
        sub,
        extraction,
        mult,
        divid,
        
    }

    private Operation o;
    private void Awake()
    {
        _money = FindObjectOfType<MoneyMover>();
        operationIndex = UnityEngine.Random.Range(1, 4);
        operationNumber = UnityEngine.Random.Range(0, 4);
        RandomOperation();
        PrintText();
        
    }

    void RandomOperation()
    {
        if (operationNumber==0)
        {
            o = Operation.sub;
        } 
        if (operationNumber==1)
        {
            o = Operation.extraction;
        }
        if (operationNumber==2)
        {
            o = Operation.mult;
        }
        if (operationNumber==3)
        {
            o = Operation.divid;
        }
    }

    void PrintText()
    {
        if (o==Operation.sub)
        {
            operationText.text = "+" + operationIndex.ToString();
        }
        if (o==Operation.extraction)
        {
            operationText.text = "-" + operationIndex.ToString();
        }
        if (o==Operation.mult)
        {
            operationText.text = "x" + operationIndex.ToString();
        }
        if (o==Operation.divid)
        {
            operationText.text = "/" + operationIndex.ToString();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Char"))
        {
            if (other.gameObject.transform.GetChild(0).name=="CharLeft")
            {
                LeftScoreChange();
                OperationBegin(_money.leftParent,moneyCountLeft);
                ProvidingMoney(_money.leftParent,GameManager.Instance.leftScore);
            }
            if (other.gameObject.transform.GetChild(0).name=="CharRight")
            {
               RightScoreChange();
               OperationBegin(_money.rightParent,moneyCountRight);
               ProvidingMoney(_money.rightParent,GameManager.Instance.rightScore);
            }
        }
    }

    void LeftScoreChange()
    {
        if (o==Operation.sub)
        {
            GameManager.Instance.IncreaseLeftScore(operationIndex);
            moneyCountLeft = operationIndex;
        }

        if (o==Operation.extraction)
        {
            GameManager.Instance.DecreaseLeftScore(operationIndex);
            moneyCountLeft = operationIndex;
        }

        if (o==Operation.mult)
        {
            GameManager.Instance.IncreaseLeftScore(GameManager.Instance.leftScore*(operationIndex-1));
            moneyCountLeft = GameManager.Instance.leftScore*(operationIndex-1);
        }

        if (o==Operation.divid)
        {
            GameManager.Instance.DecreaseLeftScore((GameManager.Instance.leftScore/operationIndex)*(operationIndex-1));
            moneyCountLeft = (GameManager.Instance.leftScore/operationIndex)*(operationIndex-1);
        }
    }

    void RightScoreChange()
    {
        if (o==Operation.sub)
        {
            GameManager.Instance.IncreaseRightScore(operationIndex);
            moneyCountRight = operationIndex;
        }

        if (o==Operation.extraction)
        {
            GameManager.Instance.DecreaseRightScore(operationIndex); 
            moneyCountRight = operationIndex;
        }

        if (o==Operation.mult)
        {
            GameManager.Instance.IncreaseRightScore(GameManager.Instance.rightScore*(operationIndex-1));
            moneyCountRight = GameManager.Instance.rightScore*(operationIndex-1);
        }

        if (o==Operation.divid)
        {
            GameManager.Instance.DecreaseRightScore((GameManager.Instance.rightScore/operationIndex)*(operationIndex-1));
            moneyCountRight = (GameManager.Instance.rightScore/operationIndex)*(operationIndex-1);
        }
    }

    void OperationBegin(GameObject parent , int count)
    {
        if (o==Operation.sub || o==Operation.mult)
        {
                    
            for (int i = 0; i < count; i++)
            {
                Instantiate(_money.moneyPrefab
                    ,(parent.transform.GetChild(parent.transform.childCount-1).transform.position+new Vector3(0,0.1f,0))
                    , Quaternion.identity
                    ,parent.transform);
            }
        }

        if (o==Operation.extraction || o==Operation.divid)
        {
            int ownMoney = parent.transform.childCount - 1;
            if (count>ownMoney)
            {
                for (int i = 0; i < ownMoney; i++)
                {
                    Destroy(parent.transform.GetChild(i).gameObject);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Destroy(parent.transform.GetChild(parent.transform.childCount-1-i).gameObject);
                }
            }
                    
        }
    }

    void ProvidingMoney(GameObject parent,int score)
    {
        if (score>parent.transform.childCount-2)
        {
            int missing = score - parent.transform.childCount - 2;
            for (int i = 0; i < missing; i++)
            {
                Instantiate(_money.moneyPrefab
                    ,(parent.transform.GetChild(parent.transform.childCount-1).transform.position+new Vector3(0,0.1f,0))
                    , Quaternion.identity
                    ,parent.transform);
            }
        }
        else if (score<parent.transform.childCount-2 && score!=0)
        {
            int missing = parent.transform.childCount - 1 - score;
            for (int i = 0; i < missing; i++)
            {
                Destroy(parent.transform.GetChild(parent.transform.childCount-1-i).gameObject);
            }
        }
    }
}
