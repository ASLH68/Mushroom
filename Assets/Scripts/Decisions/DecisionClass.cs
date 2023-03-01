/*****************************************************************************
// File Name :         DecisionClass.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     February 28th, 2023
//
// Brief Description : This document is the base class for decisions.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DecisionClass
{
    [SerializeField] private string _name;
    [SerializeField] private int _weight;
    [SerializeField] private List<string> _choices;
    [SerializeField] private int _choiceMade;

    public string Name => _name;
    public int Weight => _weight;
       
    public int ChoiceMade => _choiceMade;
}
