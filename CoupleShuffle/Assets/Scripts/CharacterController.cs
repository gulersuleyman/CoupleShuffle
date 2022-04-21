using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    public bool caseTime = false;
    void Update()
    {
        if (!caseTime)
        {
            transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Case"))
        {
            caseTime = true;
        }
    }
}
