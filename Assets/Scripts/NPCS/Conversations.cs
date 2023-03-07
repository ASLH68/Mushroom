/*****************************************************************************
// File Name :         Conversations.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     March 05, 2023
//
// Brief Description : This class holds a list of dialogue for each 
                       conversation instance.    
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Conversations
{
    [SerializeField] private int _conversationNum;
    public List<NPCDialogue> _conversationDialogues;

    [SerializeField][Tooltip("Conversation continues once player has selected their response")] 
    private bool _continueConversation;
    public bool ContinueConversation => _continueConversation;
    public int ConversationNum => _conversationNum;
}
