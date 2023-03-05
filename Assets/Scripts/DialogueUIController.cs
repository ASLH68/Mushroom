using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class DialogueUIController : MonoBehaviour
{
    public static DialogueUIController main;

    [SerializeField] private GameObject _npcDialoguePanel;
    [SerializeField] private GameObject _dialogueOptionPanel;
    [SerializeField] private GameObject _interactKeyDisplay;

    private bool _canTalk;  //whether the play is able to talk to the NPC or not
    public bool CanTalk => CanTalk;

    private void Awake()
    {
        if(main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _canTalk)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            FirstPersonController.main.IsControllable = false;
            _npcDialoguePanel.SetActive(true);
        }
    }
    public void SetCanTalk(bool val)
    {
        _canTalk = val;
    }

    /// <summary>
    /// Activates stuff when the button is pressed
    /// </summary>
    public void ButtonPressed()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FirstPersonController.main.IsControllable = true;
        _interactKeyDisplay.SetActive(false);
        _npcDialoguePanel.SetActive(false);
        _dialogueOptionPanel.SetActive(false);
    }

    /// <summary>
    /// Enables & Disables the interact key display
    /// </summary>
    public void ShowInteractKey()
    {
        _interactKeyDisplay.SetActive(true);
    }   
    public void HideInteractKey()
    {
        _interactKeyDisplay.SetActive(false);
    }

    /// <summary>
    /// Enables and disables the dialogue canvas option
    /// </summary>
    public void ShowNPCDialogue()
    {
        _npcDialoguePanel.SetActive(true);
    }
    public void HideNPCDialogue()
    {
        _npcDialoguePanel.SetActive(false);
    }

    /// <summary>
    /// Enables and disables the Dialogue Options panel
    /// </summary>
    public void ShowDialogueOptions()
    {
        _dialogueOptionPanel.SetActive(true);
    }
    public void HideDialogueOptions()
    {
        _dialogueOptionPanel.SetActive(false);
    }
}
