using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMover : MonoBehaviour
{
    private DynamicJoystick jj;

    private void Awake()
    {
        jj = FindObjectOfType<DynamicJoystick>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log(jj.Horizontal);
        }
    }
}
