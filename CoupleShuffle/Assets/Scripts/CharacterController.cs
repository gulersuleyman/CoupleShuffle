using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    

    void Update()
    {
        
        transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed);
    }
}
