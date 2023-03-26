using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EmotionDisplay : MonoBehaviour
{
    public static EmotionDisplay main;

    [SerializeField] private GameObject _emotionImage;

    [SerializeField] private Sprite _happySprite;
    [SerializeField] private Sprite _neutralSprite;
    [SerializeField] private Sprite _sadSprite;

    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
    }

    /// <summary>
    /// Sets the emotion image to whatever emotion is required
    /// </summary>
    /// <param name="emotion"></param>
    public void SetEmotionImage(string emotion)
    {
        switch(emotion)
        {
            case "HAPPY":
                _emotionImage.GetComponent<Image>().sprite = _happySprite;
                return;
            case "NEUTRAL":
                _emotionImage.GetComponent<Image>().sprite = _neutralSprite;
                return;
            case "SAD":
                _emotionImage.GetComponent<Image>().sprite = _sadSprite;
                return;    
        }
    }

    /// <summary>
    /// Displays an emotion temporarily
    /// </summary>
    /// <param name="emotion"></param>
    /// <returns></returns>
    public IEnumerator ShowTemporaryEmotion(string emotion)
    {
        bool imageSet = false;

        while(!imageSet)
        {
            SetEmotionImage(emotion);
            imageSet = true;
            yield return new WaitForSeconds(2.25f);
        }
        SetEmotionImage(NPCManager.main.CurrentNPC.CurrentEmotion);
    }
}
