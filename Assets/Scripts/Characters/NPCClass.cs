using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCClass : MonoBehaviour
{
    protected string _name;

    [Range(-50, 50)]
    protected int _emotionalState;

    public string Name => name;
}
