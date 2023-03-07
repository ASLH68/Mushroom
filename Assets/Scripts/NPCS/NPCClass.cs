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

    [SerializeField] private MoodBarUI _moodBarUI;
    public MoodBarUI MoodBarUI => _moodBarUI;

    [SerializeField] private GameObject _moodBarGameObj;
    public GameObject MoodBarGameObj => _moodBarGameObj;
    #endregion

    #region Dialogue vars

    // List of dialogue for each NPC conversation
    [Header("Conversations & Dialogue")]
    [SerializeField] private List<Conversations> _conversations;

    [HideInInspector] public Conversations CurrentConversation;
    [HideInInspector] public List<NPCDialogue> CurrentConvoDialogue;

    private int _conversationNum;
    public int ConversationNum => _conversationNum;
    #endregion

    private void Start()
    {
        _isInteractable = true;
        _conversationNum = 0;

        if(_conversations.Count > 0)
        {
            CurrentConversation = _conversations[_conversationNum];
            CurrentConvoDialogue = CurrentConversation._conversationDialogues;
        }      
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

        _moodBarUI.FillEmotionMeter();
    }

    /// <summary>
    /// Changes to the next conversation
    /// </summary>
    public void ChangeConversation()
    {
        if(_conversationNum == _conversations.Count-1)
        {
            _isInteractable = false;
            DialogueUIController.main.HideInteractKey();
        }
        else 
        {
            _conversationNum++;
            CurrentConversation = _conversations[_conversationNum];
            CurrentConvoDialogue = CurrentConversation._conversationDialogues;
        }
    }
}
