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
    int cycleNumber = 0;
    [SerializeField] NPCClass _harry;
    [SerializeField] NPCClass _fiona;
    [SerializeField] TextMeshProUGUI _popUpText;
    [SerializeField] TimedEventPopUp _popUpObject;

    // Objects to instantiate
    [SerializeField] GameObject _harryPrefab;
    [SerializeField] GameObject _fionaPrefab;
    [SerializeField] GameObject _placeholderObj;

    // NPCs to setactive
    GameObject currentEventNPCs;
    [SerializeField] List<GameObject> eventNPC = new List<GameObject>();

    // Events
    // Default
    Event _event0;
    // Emotion events
    Event _event1;
    Event _event2;
    Event _event3;
    Event _event4;
    // Nightly events
    Event _event5;
    Event _event6;
    Event _event7;
    Event _event8;
    Event _event9;
    // Daily events
    Event _event10;
    Event _event11;
    Event _event12;

    // Event object sets
    [SerializeField] List<GameObject> _defaultObj;
    [SerializeField] List<GameObject> _objs6;
    [SerializeField] List<GameObject> _objs10;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Init vars
        /*_harry = GameObject.FindGameObjectWithTag("npc1")
            .GetComponent<NPCClass>();
        _fiona = GameObject.FindGameObjectWithTag("npc2")
            .GetComponent<NPCClass>();*/
        _defaultObj = new List<GameObject> { _placeholderObj };

        // Init events
        _event0 = new Event(0, "default", _defaultObj,
                            "Nothing of note happened");
        // Emotions
        _event1 = new Event(1, "harryHappy", _defaultObj,
                            "Harry is happy today");
        _event2 = new Event(2, "harrySad", _defaultObj, "Harry is sad today");
        _event3 = new Event(3, "fionaHappy", _defaultObj,
                            "Fiona is happy today");
        _event4 = new Event(4, "fionaSad", _defaultObj, "Fiona is sad today");
        // Nightlies
        _event5 = new Event(5, "unlitFire", _defaultObj,
            "The fire needs to be lit");
        _event6 = new Event(6, "fionaSkull", _objs6,
            "Fiona found a skull on the ground");
        _event7 = new Event(7, "thunderstorm", _defaultObj,
            "A thunderstorm rages");
        // Dailies
        _event10 = new Event(10, "fionaRing", _objs10,
            "Fiona has lost her ring");
        _event11 = new Event(11, "treeFall", _defaultObj,
            "A tree fell on your tent");
        _event12 = new Event(12, "foodMissing", _defaultObj,
            "You wake up to find your food missing"); // "GASP!" -Sena Xenoblade
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

        //Vars
        List<Event> eventPool = new List<Event>();

        if (_popUpObject.WasDay)
        {
            switch (cycleNumber)
            {
                case 0:
                    PrepareEvent(_event5);
                    break;
                case 1:
                    PrepareEvent(_event6);
                    break;
                case 2:
                    PrepareEvent(_event7);
                    break;
                default:
                    PrepareEvent(_event0);
                    break;
            }
        }
        else
        {
            // Adds events to pool of potential events if their conditions are
            // met
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

            // Chooses between potential events, or triggers a default event
            // if there are none
            if (eventPool.Count == 0)
            {
                switch (cycleNumber)
                {
                    case 0:
                        PrepareEvent(_event10);
                        break;
                    case 1:
                        PrepareEvent(_event11);
                        break;
                    case 2:
                        PrepareEvent(_event12);
                        break;
                    default:
                        PrepareEvent(_event0);
                        break;
                }
            }
            else
            {
                PrepareEvent(eventPool[Random.Range(0, eventPool.Count)]);
                eventPool.Clear();
            }

            // Advances daily progression
            cycleNumber++;
        }       
    }

    /// <summary>
    /// Destroys objects used by previous events, sets event text, and
    /// instantiate objects for new events
    /// </summary>
    /// <param name="i">Event to implement</param>
    void PrepareEvent(Event i)
    {
        // Prevents event from repeating
        i.HasPlayed = true;

        // Destroys objects used by events
        foreach (GameObject go in
                 GameObject.FindGameObjectsWithTag("EventObject"))
        {
            if(!i.EventObjects.Contains(go))
            {
                go.SetActive(false);
            }
        }

        // Gets the correct NPCs into place
        if(currentEventNPCs != null)
        {
            currentEventNPCs.SetActive(false);
        }
        else
        {
            eventNPC[0].SetActive(false);
        }
        currentEventNPCs = eventNPC[i.EventID];
        currentEventNPCs.SetActive(true);

        // Sets display text and new objects
        foreach (GameObject go in i.EventObjects)
        {
            go.SetActive(true);
        }
        _popUpText.text = i.DisplayText;
        _popUpObject.ActivatePopUp();
    }

}
