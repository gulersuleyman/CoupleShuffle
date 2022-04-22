using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPoint : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    
    void Update()
    {
        if (GameManager.Instance.began && !GameManager.Instance.endSwipe)
        {
            transform.position = parent.transform
                                     .GetChild(parent.transform.childCount - 1).transform.position
                                 + new Vector3(0,0.1f,0);
        }
        
    }
}
