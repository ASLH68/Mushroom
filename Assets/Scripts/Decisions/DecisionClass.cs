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
public class DecisionClass : MonoBehaviour
{
    protected new string name;
    protected new int weight;
    protected new List<string> Choices;   
    protected new int choiceMade;
}
