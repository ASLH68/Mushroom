/*****************************************************************************
// File Name :         NPCManager.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     March 03, 2023
//
// Brief Description : This class manages the NPCs.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager main;

/*    private GameObject[] NPCObjects;
    private Dictionary<string, NPCDialogue> NPC1Dictionary;*/

    private NPCClass _currentNPC;   // NPC currently being interacted with
    public NPCClass CurrentNPC => _currentNPC;

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
        //NPCObjects = GameObject.FindGameObjectsWithTag("Character");

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
}
