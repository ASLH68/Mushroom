using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class DecisionManager : MonoBehaviour
{
    public static DecisionManager main;

    private enum DECISIONS
    {

    }

    [SerializeField] private List<DecisionClass> DecisionClasses;
    public Dictionary<string, DecisionClass> DecisionDictionary;

    public List<DecisionClass> DecisionList => DecisionClasses;

    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        DecisionDictionary = new Dictionary<string, DecisionClass>();

        foreach (var decision in DecisionClasses)
        {
            DecisionDictionary.Add(decision.Name, decision);
        }
    }
}
