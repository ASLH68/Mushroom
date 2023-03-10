/*****************************************************************************
// File Name :         DialogueUIController.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     March 03, 2023
//
// Brief Description : This class controls the Dialogue UI
*****************************************************************************/
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Cursor = UnityEngine.Cursor;

public class DialogueUIController : MonoBehaviour
{
    public static DialogueUIController main;

    [SerializeField] private TextMeshProUGUI _npcDialogueText;
    [SerializeField] private TextMeshProUGUI _npcNameText;

    [Header("Panels")]
    [SerializeField] private GameObject _npcDialoguePanel;
    [SerializeField] private GameObject _dialogueOptionPanel;
    [SerializeField] private GameObject _interactKeyDisplay;

    [Header("Button Choices")]
    //[SerializeField] private List<TextMeshProUGUI> _buttonChoices;
    [SerializeField] private List<GameObject> _buttonChoiceObjs;
    private List<Button> _buttonChoices = new List<Button>();
    [SerializeField] private GameObject _nextButton;

    private DecisionClass _currentDecision;
    public DecisionClass CurrentDecision => _currentDecision;

    private bool _canTalk;  //whether the play is able to talk to the NPC or not
    public bool CanTalk => _canTalk;

    #region Awake, Start, Update
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
        LockCursor();
    }

    private void Start()
    {
        _canTalk = true;
        foreach(GameObject obj in _buttonChoiceObjs)
        {
            _buttonChoices.Add(obj.GetComponent<Button>());
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _canTalk)
        {
            _canTalk = false;
            UnlockCursor();
            FirstPersonController.main.IsControllable = false;

            HideInteractKey();
            DisplayDialogue();

            _npcDialoguePanel.SetActive(true);
        }
    }
    #endregion

    /// <summary>
    /// Sets whether or not the NPC can be interacted with
    /// </summary>
    /// <param name="val"></param>
    public void SetCanTalk(bool val)
    {
        _canTalk = val;
    }

    /// <summary>
    /// Locks the cursor, returns control to the character, and disables the
    /// dialogue UI
    /// </summary>
    public void EndDialogue()
    {
        /*LockCursor();
        FirstPersonController.main.IsControllable = true;
        HideInteractKey();
        HideNPCDialogue();
        HideDialogueOptions();
        HideMoodBar();*/
    }

    #region Visibility Functions
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
        if(NPCManager.main.CurrentNPC.IsInteractable)
        {
            EnableChoiceButtons();
        }
        else
        {
            DisableChoiceButtons();
        }
    }
    public void HideDialogueOptions()
    {
        _dialogueOptionPanel.SetActive(false);
    }

    /// <summary>
    /// Enables and disables the mood bar from showing
    /// </summary>
    public void ShowMoodBar()
    {
        NPCManager.main.CurrentNPC.MoodBarGameObj.SetActive(true);
    }
    public void HideMoodBar()
    {
        NPCManager.main.CurrentNPC.MoodBarGameObj.SetActive(false);
    }
    #endregion

    /// <summary>
    /// Sets the dialogue text on screen
    /// </summary>
    /// <param name="text"></param>
    private void SetDialogueText(string text)
    {
        _npcDialogueText.text = text;
    }

    /// <summary>
    /// Displays the dialogue associated with the NPCs emotions in the current conversation
    /// </summary>
    private void DisplayDialogue()
    {
        NPCClass currentNPC;
        currentNPC = NPCManager.main.CurrentNPC;

        foreach(NPCDialogue npcDialogue in currentNPC.CurrentConvoDialogue)
        {
            if(currentNPC.CurrentEmotion.Equals(npcDialogue.CurrentEmotion.ToString()))
            {
                SetDialogueText(npcDialogue.Dialogue);
            }
        }
        _npcNameText.text = NPCManager.main.CurrentNPC.NPCName;
        ShowMoodBar();
        ShowDialogueOptions();
        SetOptions();
    }

    public void OptionSelected(int optionNum)
    {
        if(optionNum != 0)
        {
            DisableChoiceButtons();
            _currentDecision.SetChoice(optionNum);

            int relativeWeight = _currentDecision.Weight;

            switch (optionNum)
            {
                case 2:
                    relativeWeight = 0;
                    break;
                case 3:
                    relativeWeight = -relativeWeight;
                    break;
            }

            NPCManager.main.CurrentNPC.SetMood(relativeWeight);
        }
        
        if (NPCManager.main.CurrentNPC.CurrentConversation.ContinueConversation)
        {
            NPCManager.main.CurrentNPC.ChangeConversation();
            DisplayDialogue();
        }
    }

    /// <summary>
    /// Closes the dialogue UI and ends the conversation
    /// </summary>
    public void LeaveNPC()
    {
        _canTalk = true;
        LockCursor();
        FirstPersonController.main.IsControllable = true;
        HideNPCDialogue();
        HideDialogueOptions();
        HideMoodBar();
        ShowInteractKey();

        if(_currentDecision.ChoiceMade != 0)
        {
            NPCManager.main.CurrentNPC.ChangeConversation();
        }
    }

    /// <summary>
    /// Disables & Enables the choice button options
    /// </summary>
    private void DisableChoiceButtons()
    {
        foreach(Button butt in _buttonChoices)
        {
            butt.interactable = false;
        }
    }
    private void EnableChoiceButtons()
    {
        foreach(Button butt in _buttonChoices)
        {
            butt.interactable = true;
        }
    }

    private void ShowChoiceButtons()
    {
        foreach(GameObject obj in _buttonChoiceObjs)
        {
            obj.SetActive(true);
        }
    }
    public void HideChoiceButtons()
    {
        foreach (GameObject obj in _buttonChoiceObjs)
        {
            obj.SetActive(false);
        }
    }

    /// <summary>
    /// Sets the option text
    /// </summary>
    private void SetOptions()
    {
        bool hasDecision = false;
        foreach(DecisionClass dec in DecisionManager.main.DecisionList)
        {
            if(dec.AssociatedConversation == NPCManager.main.CurrentNPC.ConversationNum && 
                NPCManager.main.CurrentNPC.Equals(dec.AssociatedNPC))
            {
                _currentDecision = dec;
                for(int i = 0; i < _buttonChoices.Count; i++)
                {
                    _buttonChoices[i].GetComponentInChildren<TextMeshProUGUI>().text = dec.Choices[i];
                }
                ShowChoiceButtons();
                hasDecision = true;
                break;
            }
        }
        _nextButton.SetActive(!hasDecision);

        if(!hasDecision)
        {
            HideChoiceButtons();
        }
        
    }
    #region Cursor
    /// <summary>
    /// Hides and locks the cursor
    /// </summary>
    private void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// Unhides and unlocks the cursor
    /// </summary>
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    #endregion
}
