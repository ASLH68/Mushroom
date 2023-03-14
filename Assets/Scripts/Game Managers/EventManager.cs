/*****************************************************************************
// File Name :         EventManager.cs
// Author :            Peter Campbell
// Creation Date :     March 13, 2023
//
// Brief Description : Determines which event to play and instantiates needed
                       onjects.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventManager : MonoBehaviour
{
    // Vars
    //public int eventID = 0;
    NPCClass _harry;
    NPCClass _fiona;
    [SerializeField] TextMeshProUGUI _popUpText;
    [SerializeField] TimedEventPopUp _popUpObject;

    // Objects to instantiate
    [SerializeField] GameObject _harryPrefab;
    [SerializeField] GameObject _fionaPrefab;
    [SerializeField] GameObject _placeholderObj;

    // Events
    // Default
    Event _event0;
    // Emotion events
    Event _event1;
    Event _event2;
    Event _event3;
    Event _event4;
    // Daily events

    // Event object sets

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Init vars
        _harry = GameObject.FindGameObjectWithTag("npc1")
            .GetComponent<NPCClass>();
        _fiona = GameObject.FindGameObjectWithTag("npc2")
            .GetComponent<NPCClass>();

        // Init events
        _event0 = new Event(0, "default", null, "Nothing of note happened");
        _event1 = new Event(1, "harryHappy", null, "Harry is happy today");
        _event2 = new Event(2, "harrySad", null, "Harry is sad today");
        _event3 = new Event(3, "fionaHappy", null, "Fiona is happy today");
        _event4 = new Event(4, "fionaSad", null, "Fiona is sad today");
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// Determines which event to trigger
    /// </summary>
    public void SelectEvent()
    {
        // Vars
        Event candidate = new Event();
        List<Event> eventPool = new List<Event>();

        // Adds events to pool of potential events if their conditions are met
        if (_harry.MoodVal >= 75 && !_event1.HasPlayed)
        {
            eventPool.Add(_event1);
        }
        if (_harry.MoodVal <= 25 && !_event2.HasPlayed)
        {
            eventPool.Add(_event2);
        }
        if (_fiona.MoodVal >= 75 && !_event3.HasPlayed)
        {
            eventPool.Add(_event3);
        }
        if (_fiona.MoodVal <= 25 && !_event4.HasPlayed)
        {
            eventPool.Add(_event4);
        }

        // Chooses between potential events, or triggers a default event if
        // there are none
        if (eventPool.Count == 0)
        {
            PrepareEvent(_event0);
        }
        else
        {
            PrepareEvent(eventPool[Random.Range(0, eventPool.Count)]);
            eventPool.Clear();
        }
    }

    /// <summary>
    /// Destroys objects used by previous events, sets event text, and
    /// instantiate objects for new events
    /// </summary>
    /// <param name="i">Event to implement</param>
    void PrepareEvent(Event i)
    {
        // Destroys objects used by events
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("EventObject"))
        {
            Destroy(go);
        }

        // Sets display text and new objects
        _popUpText.text = i.DisplayText;
        _popUpObject.ActivatePopUp();
        foreach(GameObject go in i.EventObjects)
        {
            Instantiate(go);
        }
    }

}
