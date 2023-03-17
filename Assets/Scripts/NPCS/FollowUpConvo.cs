using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FollowUpConvo
{
    [SerializeField] private int _decisionChoiceNum;
    [SerializeField] private int _nextConvoNum;

    public int DecisionChoiceNum => _decisionChoiceNum;
    public int NextConvoNum => _nextConvoNum;
}
