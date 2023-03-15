/*****************************************************************************
// File Name :         Event.cs
// Author :            Peter Campbell
// Creation Date :     March 14, 2023
//
// Brief Description : Shell information for events
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    // Vars
    int _ID;
    string _name;
    string _displayText;
    List<GameObject> _eventObjects = new List<GameObject> { };

    bool _hasPlayed;

    //Getters/Setters
    public string DisplayText { get => _displayText;
        set => _displayText = value; }
    public List<GameObject> EventObjects { get => _eventObjects;
        set => _eventObjects = value; }
    public bool HasPlayed { get => _hasPlayed; set => _hasPlayed = value; }

    /// <summary>
    /// Default Constructor
    /// </summary>
    public Event()
    {

    }

    /// <summary>
    /// Constructor with all values
    /// </summary>

    public Event(int ID, string name, List<GameObject> eventObjects,
                 string displayText)
    {
        _ID = ID;
        _name = name;
        _displayText = displayText;

        if (eventObjects.Count > 0)
        {
            foreach (GameObject i in eventObjects)
            {
                _eventObjects.Add(i);
            }
        }
    }
}
