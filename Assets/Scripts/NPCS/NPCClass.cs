/*****************************************************************************
// File Name :         NPCClass.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     March 03, 2023
//
// Brief Description : This class controls each individual NPC
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCClass : MonoBehaviour
{
    // NPCs name
    [SerializeField] protected string _name;
    public string Name => name;

    // Whether or not the NPC is able to be interacted with
    protected bool _isInteractable;
    public bool IsInteractable => _isInteractable;

    #region Emotion vars
    /// <summary>
    /// Possible NPC Emotions
    /// </summary>
    private enum Emotion
    {
        HAPPY,
        NEURTRAL,
        SAD
    }

    // NPC's current emotion
    private Emotion _emotion = Emotion.NEURTRAL;
    public string CurrentEmotion => _emotion.ToString();

    // current emotion is controlled by the _moodVal
    [Range(0, 100)]
    private int _moodVal = 50;
    public int MoodVal => _moodVal;

    // each max amount that will be considered to activate an emotion
    [Header("Emotion Variables")]
    [Range(0, 100)]
    [Tooltip("Highest amount that will be considered sad.")]
    [SerializeField] private int _sadThreshhold;
    
    [Range(0, 100)]
    [Tooltip("Highest amount that will be considered neutral.")]
    [SerializeField] private int _neutralThreshhold;
    
    [Range(0, 100)]
    [Tooltip("Highest amount that will be considered happy.")]
    [SerializeField] private int _happyThreshhold;
    #endregion

    #region Dialogue vars

    // List of dialogue for each NPC conversation
    [Header("Dialogue")]
    [SerializeField] private List<Conversations> _conversations;
    //[SerializeField] private List<NPCDialogue> _conversation1;

    [HideInInspector] public List<NPCDialogue> CurrentConversation;

    private int _conversationNum;
    public int ConversationNum => _conversationNum;
    #endregion

    private void Start()
    {
        _isInteractable = true;
        //CurrentConversation = _conversation1;
        _conversationNum = 0;
        CurrentConversation = _conversations[_conversationNum]._conversationDialogues;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player") && _isInteractable)
        {
            DialogueUIController.main.ShowInteractKey();
            DialogueUIController.main.SetCanTalk(true);
            NPCManager.main.SetCurrentNPC(this.gameObject.GetComponent<NPCClass>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Player") && _isInteractable)
        {
            DialogueUIController.main.HideInteractKey();
            DialogueUIController.main.SetCanTalk(false);
        }
    }

    private void SetDialogue(string dialogue)
    {
        DialogueUIController.main.SetDialogueText(dialogue);
    }

    public void SetMood(int changeNum)
    {
        _moodVal += changeNum;

        if(_moodVal > _neutralThreshhold)
        {
            _emotion = Emotion.HAPPY;
        }
        else if (_moodVal > _sadThreshhold)
        {
            _emotion = Emotion.NEURTRAL;
        }
        else
        {
            _emotion = Emotion.SAD;
        }
    }
}
