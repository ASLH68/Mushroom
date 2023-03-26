/*****************************************************************************
// File Name :         MoodBarUI.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     March 6th, 2023
//
// Brief Description : This class controls the NPC's mood bar
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MoodBarUI : MonoBehaviour
{
    [SerializeField] private Image _emotionMeterIMG;
    [SerializeField] private NPCClass _npcReference;
    [SerializeField] private int whichNPC;

    private void Start()
    {
        GetNPC();
        FillEmotionMeter();
    }

    public void GetNPC()
    {
        string npc = "";
        if(whichNPC == 1)
        {
            npc = "npc1";
        }
        else if(whichNPC == 2)
        {
            npc = "npc2";
        }
        _npcReference = GameObject.FindGameObjectWithTag(npc).GetComponentInChildren<NPCClass>();
    }

    /// <summary>
    /// Fills the mood bar with the NPC's current mood value
    /// </summary>
    public void FillEmotionMeter()
    {
        //_emotionMeterIMG.fillAmount = (float)_npcReference.MoodVal/100;
    }
}
