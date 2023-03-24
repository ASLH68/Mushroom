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

public class SkipTime : MonoBehaviour
{
    // Vars
    [SerializeField] EventManager _em;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _buttonIcon;
    Vector3 _playerPos;
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
        if (GetComponent<CapsuleCollider>().bounds.Contains(_playerPos))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _em.SelectEvent();
            }
        }
    }

    /// <summary>
    /// Triggers when object enters trigger space
    /// </summary>
    /// <param name="other">object this collides with</param>
    private void OnTriggerEnter(Collider other)
    {
        _buttonIcon.SetActive(true);
    }

    /// <summary>
    /// Called when object exits trigger space
    /// </summary>
    /// <param name="other"> object this collides witj=h</param>
    private void OnTriggerExit(Collider other)
    {
        _buttonIcon.SetActive(false);
    }


}
