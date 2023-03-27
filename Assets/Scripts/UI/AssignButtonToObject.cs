/*****************************************************************************
// File Name :         AssignButtonToObject.cs
// Author :            Peter Campbell
// Creation Date :     March 25th, 2023
//
// Brief Description : Assigns interactable object to buttons command
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignButtonToObject : MonoBehaviour
{
    // Vars
    GameObject _targetObject;
    [SerializeField] bool _isLeaveButton;
    [SerializeField] private SkipTime _skipTime;

    /// <summary>
    /// Enables assigned object to be picked up.
    /// </summary>
    /// <param name="i">Gameobject to assign this to</param>
    public void AssignObject(GameObject i)
    {
        _targetObject = i;
    }

    /// <summary>
    /// Disables UI and enbales object to be picked up if applicable
    /// </summary>
    public void RemoveUI()
    {
        if (!_isLeaveButton)
        {
            _targetObject.GetComponent<InteractableObject>().EnablePickUp();
        }
        _targetObject.GetComponent<InteractableObject>().DisableUI();
        _skipTime.ShowButtonIcon();
    }
}
