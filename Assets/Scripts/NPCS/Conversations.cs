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
    [SerializeField] private List<FollowUpConvo> _followUpConvos;

    [SerializeField][Tooltip("Conversation continues once player has selected their response")] 
    private bool _continueConversation;
    public bool ContinueConversation => _continueConversation;
    public int ConversationNum => _conversationNum;

    /// <summary>
    /// Checks for a follow up conversation, otherwise simply changes the conversation to the next one
    /// </summary>
    public bool CheckFollowUp()
    {
        if(_followUpConvos != null && _followUpConvos.Count > 0)
        {
            foreach(FollowUpConvo followUpConvo in _followUpConvos)
            {
                if(followUpConvo.DecisionChoiceNum == DialogueUIController.main.CurrentDecision.ChoiceMade)
                {
                    NPCManager.main.CurrentNPC.SetNextConvoNum(followUpConvo.NextConvoNum);
                    return true;
                }
            }
        }
        return false;
    }
}
