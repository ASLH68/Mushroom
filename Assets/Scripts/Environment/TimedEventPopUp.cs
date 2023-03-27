/*****************************************************************************
// File Name :         TimedEventPopUp.cs
// Author :            Peter Campbell
// Creation Date :     March 3rd, 2023
//
// Brief Description : This class displays pop up message at the start and
                       end of each day.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimedEventPopUp : MonoBehaviour
{
    // Vars
    // Text to alter
    [SerializeField] GameObject _textObject;
    public TextMeshProUGUI /*_text*/titleText;
    // Time Management
    [SerializeField] TimeCycleScript _timeCycle;
    bool _wasDay = false;
    public bool WasDay { get => _wasDay; set => _wasDay = value; }
    // Pop up objects
    [SerializeField] GameObject _popUpBG;
    [SerializeField] GameObject _popUpButton;
    // Misc
    //bool _openingScene = true;

    // Event Text
    /*int _eveningOrder;
    [SerializeField] private List<string> eveningEventTitle = new List<string>();
    [SerializeField] private List<string> eveningEventDescription = new List<string>();
    /*string[] _eveningEvents = new string[]
    { "You light the campfire for the first time." };

    int _morningSelection;
    [SerializeField] private List<string> morningEventTitle = new List<string>();
    [SerializeField] private List<string> morningEventDescription = new List<string>();*/
    //string[] _morningEvents = new string[] { };

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Initialize Vars
        /*_text*/titleText = _textObject.GetComponent<TextMeshProUGUI>();

        // Set up for initial screen
        // Enable Cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Hide Pop Up
        /*_popUpBG.SetActive(false);
        _popUpButton.SetActive(false);

        _textObject.GetComponent<CanvasRenderer>().SetAlpha(0); */
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// Displays pop up text and button
    /// </summary>
    public void ActivatePopUp()
    {
        // Set up pop up
        _popUpBG.SetActive(true);
        _popUpButton.SetActive(true);
        _textObject.GetComponent<CanvasRenderer>().SetAlpha(100);

        // Enable Cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// Resumes the game and disables popup
    /// </summary>
    public void ContinueGame()
    {
        // Disable Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //_timeCycle.cyclePercentage = _timeCycle.CycleLength / 2;

        // Starts next part of Day/Night cycle
        if (_wasDay)
        {
            StartCoroutine(_timeCycle.NightCycleController());
        }
        else
        {
            StartCoroutine(_timeCycle.DayCycleController());
        }

        _wasDay = !_wasDay;

        // Hide Pop Up
        _popUpBG.SetActive(false);
        _textObject.GetComponent<CanvasRenderer>().SetAlpha(0);
        _popUpButton.SetActive(false);
    }
}
