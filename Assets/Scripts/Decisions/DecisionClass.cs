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
    [SerializeField] private string name;
    [SerializeField] private int weight;
    [SerializeField] private List<string> Choices;
    [SerializeField] private int choiceMade;

    public string Name => name;
    public int Weight => weight;
       
    public int ChoiceMade => choiceMade;
}
