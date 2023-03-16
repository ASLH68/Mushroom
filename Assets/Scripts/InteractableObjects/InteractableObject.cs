/*****************************************************************************
// File Name :         InteractableObjects.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     March 16th, 2023
//
// Brief Description : This class controls an interactable object
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private InteractablesManager.InteractableTypes _interactableType;
    public InteractablesManager.InteractableTypes InteractableType => _interactableType;

    private bool _hasBeenInteracted = false;    // If the obj has been interacted with yet
    public bool HasBeenInteracted => _hasBeenInteracted;

    private bool _isInteractable = false;   // If the player is currently able to interact with the object
    [SerializeField] private bool _destroyOnPickUp;

    private void OnTriggerEnter(Collider other)
    {
        // Enables interactivity if it has not been interacted with yet
        if(!_hasBeenInteracted)
        {
            _isInteractable = true;
        }
        InteractablesManager.main.ObjectInteraction = true;
        if (other.tag.Equals("Player") && !_hasBeenInteracted)
        {
            DialogueUIController.main.ShowInteractKey();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Disables interactability
        InteractablesManager.main.ObjectInteraction = false;
        DialogueUIController.main.HideInteractKey();
        _isInteractable = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isInteractable && !_hasBeenInteracted)
        {
            // Disables interactability and sets the hasbeeninteracted with bool
            _hasBeenInteracted = true;
            _isInteractable = false;
            DialogueUIController.main.HideInteractKey();
            
            if(_destroyOnPickUp)
            {
                gameObject.SetActive(false);
            }
        }           
    }
}
