/*****************************************************************************
// File Name :         TimeCycleScript.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     March 3rd, 2023
//
// Brief Description : This class controls the day-night cycle
*****************************************************************************/

using System.Collections;
using UnityEngine;

public class TimeCycleScript : MonoBehaviour
{
    public static TimeCycleScript main;

    private Light _light;
    //private bool _cycleChanging = true;

    private Vector3 _nightCycleStartPos = new Vector3(195f, -30f, 0f);
    private Vector3 _nightCycleEndPos = new Vector3(360, -30f, 0f);

    private Vector3 _dayCycleStartPos = new Vector3(0f, -30f, 0f);
    private Vector3 _dayCycleEndPos = new Vector3(195f, -30f, 0f);

    private float _cycleLength;

    // Daily pop up display (added by Peter)
    [SerializeField] TimedEventPopUp _popUpObject;

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

    private void Start()
    {
        _light = GameObject.FindObjectOfType<Light>();
        _cycleLength = GameController.main.CycleLength;
        StartCoroutine("DayCycleController");
    }

    public IEnumerator DayCycleController()
    {
        float _cyclePercentage = 0;

        while (_cyclePercentage < _cycleLength/2)
        {
            //_light.transform.Rotate(new Vector3(1f, 0f, 0f));
            _light.transform.eulerAngles = Vector3.Lerp(_dayCycleStartPos, _dayCycleEndPos, _cyclePercentage / (_cycleLength/2));

            _cyclePercentage += Time.deltaTime;

            yield return null;
        }
        _popUpObject.ActivatePopUp();
    }

    public IEnumerator NightCycleController()
    {
        float _cyclePercentage = 0;

        while (_cyclePercentage < _cycleLength/2)
        {
            //_light.transform.Rotate(new Vector3(1f, 0f, 0f));
            _light.transform.eulerAngles = Vector3.Lerp(_nightCycleStartPos, _nightCycleEndPos, _cyclePercentage/(_cycleLength/2));

            _cyclePercentage += Time.deltaTime;

            yield return null;
        }
        _popUpObject.ActivatePopUp();
    }

}
