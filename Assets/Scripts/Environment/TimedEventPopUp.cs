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
    TextMeshPro _text;
    // Time Management
    [SerializeField] TimeCycleScript _timeCycle;
    bool _wasDay = true;
    // Pop up objects
    [SerializeField] GameObject _popUpBG;
    [SerializeField] GameObject _popUpButton;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Initialize Vars
        _text = _textObject.GetComponent<TextMeshPro>();

        // Hide Pop Up
        _popUpBG.SetActive(false);
        _popUpButton.SetActive(false);

        _textObject.GetComponent<CanvasRenderer>().SetAlpha(0);
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

        // Set display text
        /* DISPLAY CODE HERE */
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

        // Starts next part of Day/Night cycle
        if (_wasDay)
        {
            _timeCycle.StartCoroutine("NightCycleController");
        }
        else
        {
            _timeCycle.StartCoroutine("DayCycleController");
        }

        _wasDay = !_wasDay;

        // Hide Pop Up
        _popUpBG.SetActive(false);
        _textObject.GetComponent<CanvasRenderer>().SetAlpha(0);
        _popUpButton.SetActive(false);
    }
}
