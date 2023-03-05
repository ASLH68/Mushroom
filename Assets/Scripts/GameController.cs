/*****************************************************************************
// File Name :         GameController.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     March 03, 2023
//
// Brief Description : This class controls the general gameplay structure
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController main;

    [Tooltip("Enter the number of desired minutes for one full cycle.")]
    [SerializeField] float _cycleLength;

    public float CycleLength => _cycleLength;

    private void Awake()
    {
        if(main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Turns user defined cycle length into minutes
        _cycleLength *= 60;
    }
}
