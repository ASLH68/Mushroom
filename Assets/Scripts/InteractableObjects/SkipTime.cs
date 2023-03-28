/*****************************************************************************
// File Name :         SkipTime.cs
// Author :            Peter Campbell
// Creation Date :     March 22, 2023
//
// Brief Description : Skips to the next day/night by triggering the next
                       event.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class SkipTime : MonoBehaviour
{
    // Vars
    [SerializeField] EventManager _em;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _buttonIcon;
    [SerializeField] GameObject _warning;
    [SerializeField] GameObject _alertOptions;
    Vector3 _playerPos;
    Vector3 _lastPos;
    //public bool useable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Gets player position
        _playerPos = _player.transform.position;

        // Prompts Player
        if (GetComponent<SphereCollider>().bounds.Contains(_playerPos))
        {
            // Activates Pop Up
            if (Input.GetKeyDown(KeyCode.R))
            {
                
                _buttonIcon.SetActive(false);
                /*if(!NPCManager.main.CheckNPCInteractions())
                {

                }
                else
                {
                    _em.SelectEvent();
                }*/

                /* do the things*/
                _warning.SetActive(true);
                _alertOptions.SetActive(true);
                FirstPersonController.main.IsControllable = false;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

/*            // Restores button after activating
            if (_lastPos != _playerPos)
            {
                _buttonIcon.SetActive(true);
            }*/
        }

        _lastPos = _playerPos;
    }

    /// <summary>
    /// Triggers when object enters trigger space
    /// </summary>
    /// <param name="other">object this collides with</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            _buttonIcon.SetActive(true);
        }
    }

    /// <summary>
    /// Called when object exits trigger space
    /// </summary>
    /// <param name="other"> object this collides witj=h</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            _buttonIcon.SetActive(false);
        }
    }

    public void HideButtonIcon()
    {
        _buttonIcon.SetActive(false);
    }

    public void ShowButtonIcon()
    {
        _buttonIcon.SetActive(true);
    }

    public void YesToAlert()
    {
        _em.SelectEvent();

        _warning.SetActive(false);
        _alertOptions.SetActive(false);
        FirstPersonController.main.IsControllable = true;
    }

    public void NoToAlert()
    {
        _warning.SetActive(false);
        _alertOptions.SetActive(false);
        ShowButtonIcon();
        FirstPersonController.main.IsControllable = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
