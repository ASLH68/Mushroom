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
using TMPro;
using StarterAssets;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private InteractablesManager.InteractableTypes _interactableType;
    public InteractablesManager.InteractableTypes InteractableType => _interactableType;

    private bool _hasBeenInteracted = false;    // If the obj has been interacted with yet
    public bool HasBeenInteracted => _hasBeenInteracted;

    private bool _isInteractable = false;   // If the player is currently able to interact with the object
    [SerializeField] private bool _destroyOnPickUp;
    public bool DestroyOnPickUp { get => _destroyOnPickUp; }

    // Added by Peter
    [SerializeField] string _interactableName;
    [SerializeField] string _interactableDesc;
    [SerializeField] bool _canPickUp = false;
    [SerializeField] AssignButtonToObject _leaveButton;
    [SerializeField] AssignButtonToObject _takeButton;

    // GameObjects
    [SerializeField] GameObject _descriptionUI;
    [SerializeField] GameObject _choiceButtons;
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] TextMeshProUGUI _descText;

    private void OnTriggerEnter(Collider other)
    {
        // Enables interactivity if it has not been interacted with yet
/*        if (!_hasBeenInteracted)
        {
            _isInteractable = true;
        }*/
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
            /*_hasBeenInteracted = true;
            _isInteractable = false;
            DialogueUIController.main.HideInteractKey(); */
            ActivateUI();
            DialogueUIController.main.HideInteractKey();
            _leaveButton.AssignObject(gameObject);
            _takeButton.AssignObject(gameObject);
        }
    }

    /// <summary>
    /// Activates UI and presents description
    /// </summary>
    void ActivateUI()
    {
        //Activates Text and UI
        _nameText.text = _interactableName;
        _descText.text = _interactableDesc;
        _descriptionUI.SetActive(true);
        _choiceButtons.SetActive(true);

        // Enable Cursor
        FirstPersonController.main.IsControllable = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// Handles what happens when player chooses to take or leave the item
    /// </summary>
   public void DisableUI()
    {
        // Deactivates UI
        _descriptionUI.SetActive(false);
        _choiceButtons.SetActive(false);

        // Disable Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        FirstPersonController.main.IsControllable = true;

        // Removes objects
        if (_destroyOnPickUp && _canPickUp)
        {
            DestroyInteractable();
        }
        else
        {
            DialogueUIController.main.ShowInteractKey();
        }
    }

    /// <summary>
    /// Removes item from world
    /// </summary>
    void DestroyInteractable()
    {
        _hasBeenInteracted = true;
        _isInteractable = false;
        InteractablesManager.main.ObjectInteraction = false;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Enables pick up when button is pressed
    /// </summary>
    public void EnablePickUp()
    {
        _canPickUp = true;
    }
}
