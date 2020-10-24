﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAnimation : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void ToogleParamaner(string param) {
        animator.SetBool(param, !animator.GetBool(param));
    }
}
