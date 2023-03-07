/*****************************************************************************
// File Name :         MoodBarUI.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     March 6th, 2023
//
// Brief Description : This class controls the NPC's mood bar
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoodBarUI : MonoBehaviour
{
    [SerializeField] private Image _emotionMeterIMG;
    [SerializeField] private NPCClass _npcReference;

    private void Start()
    {
        FillEmotionMeter();
    }

    /// <summary>
    /// Fills the mood bar with the NPC's current mood value
    /// </summary>
    public void FillEmotionMeter()
    {
        _emotionMeterIMG.fillAmount = (float)_npcReference.MoodVal/100;
    }
}
