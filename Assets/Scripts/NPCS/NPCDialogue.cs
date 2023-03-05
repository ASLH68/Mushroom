/*****************************************************************************
// File Name :         NPCDialogue.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     March 03, 2023
//
// Brief Description : This class holds dialogue for an NPC and its associated
                       emotion.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCDialogue
{
    /// <summary>
    /// Emotion associated with the dialogue
    /// </summary>
    public enum Emotion
    {
        HAPPY,
        NEURTRAL,
        SAD
    }

    public Emotion CurrentEmotion;

    /// <summary>
    /// The dialogue itself
    /// </summary>
    [TextArea] 
    public string Dialogue;
}
