/*****************************************************************************
// File Name :         NPCManager.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     March 03, 2023
//
// Brief Description : This class manages the NPCs.
*****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager main;

    private GameObject[] NPCObjects;
    private GameObject[] NPCObjects2;
    /*private Dictionary<string, NPCDialogue> NPC1Dictionary;*/

    private NPCClass _currentNPC;   // NPC currently being interacted with
    public NPCClass CurrentNPC => _currentNPC;

    // Gonna have to make this better; - It's messy because it has to start with the neutral val here
    // Currently used for transfering npc emotion, between events
    [NonSerialized] public int fionaMood = 50;
    [NonSerialized] public int harryMood = 50;

    #region Awake & Start
    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(main);
        }
    }

    private void Start()
    {
        NPCObjects = GameObject.FindGameObjectsWithTag("npc1");
        NPCObjects2 = GameObject.FindGameObjectsWithTag("npc2");

       /* foreach(GameObject obj in NPCObjects)
        {
            NPC1Dictionary.Add(obj.GetComponent<NPCClass>().Name, obj.GetComponent<NPCDialogue>());
        }*/
    }
    #endregion

    /// <summary>
    /// Sets the current NPC
    /// </summary>
    /// <param name="npcClass"> NPC being interacted with </param>
    public void SetCurrentNPC(NPCClass npcClass)
    {
        _currentNPC = npcClass;
    }

    /// <summary>
    /// Checks if both NPC have been fully talked to by the player
    /// </summary>
    /// <returns></returns>
    public bool CheckNPCInteractions()
    {
        bool bothInteracted = false;
        foreach (GameObject obj in NPCObjects)
        {
            if(!obj.GetComponent<NPCClass>().completedInteraction)
            {
                bothInteracted = false;
            }
        }

        return bothInteracted;
    }
}
