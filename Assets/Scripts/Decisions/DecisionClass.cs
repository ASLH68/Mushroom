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
    [SerializeField] protected new string name;
    [SerializeField] protected new int weight;
    [SerializeField] protected new List<string> Choices;
    [SerializeField] protected new int choiceMade;
}
