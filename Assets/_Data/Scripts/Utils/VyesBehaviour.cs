using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VyesBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
        this.ResetValues();
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValues();
    }

    protected virtual void LoadComponents()
    {
        //For override...
    }

    protected virtual void ResetValues()
    {
        //For override...
    }
}