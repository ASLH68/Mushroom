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
    [SerializeField] private int _associatedConversation;
    [SerializeField] private NPCClass _associatedNPC;
    [SerializeField] private int _weight;
    public List<string> Choices;
    [SerializeField] private int _choiceMade;

    public string Name => _name;
    public int AssociatedConversation => _associatedConversation;
    public NPCClass AssociatedNPC => _associatedNPC;
    public int Weight => _weight;
    public int ChoiceMade => _choiceMade;

    public void SetChoice(int num)
    {
        _choiceMade = num;
    }
}
