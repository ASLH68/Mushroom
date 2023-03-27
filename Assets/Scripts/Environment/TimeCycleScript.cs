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
    public float CycleLength { get => _cycleLength; }

    public float _speed = 0.5f;

    private bool _isPaused = false;

    // Daily pop up display (added by Peter)
    [SerializeField] TimedEventPopUp _popUpObject;
    [SerializeField] EventManager _eventManager;

    // Campfire object (Added by Peter)
    //[SerializeField] GameObject _campfire;
    private float _cyclePercentage;

    public float cyclePercentage;
    [SerializeField] private IEnumerator _currentCycle;

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
        _cycleLength = GameController.main.CycleLength * 60f;    //Turns user defined cycle length into minutes
    }

    public IEnumerator DayCycleController()
    {
        // Resets position and sets color
        cyclePercentage = 0;
        _light.color = new Color(1, 0.9568627f, 0.8392157f);

        // Moves light
        while (cyclePercentage < _cycleLength/2)
        {
            if (!_isPaused)
            {
                _light.transform.eulerAngles = Vector3.Lerp(_dayCycleStartPos, _dayCycleEndPos, cyclePercentage / (_cycleLength / 2));

                cyclePercentage += Time.deltaTime * _speed;
            }

            yield return null;
        }

        // ends function
        StopCoroutine(DayCycleController());
        //_eventManager.SelectEvent();
    }

    public IEnumerator NightCycleController()
    {
        // Resets position and sets color
        cyclePercentage = 0;
        _light.color = new Color(0.2109375f, 0.2207031f, 0.25f);

        // Moves light
        while (_cyclePercentage < _cycleLength/2)
        {
            if (!_isPaused)
            {
                _light.transform.eulerAngles = Vector3.Lerp(_nightCycleStartPos, _nightCycleEndPos, cyclePercentage / (_cycleLength / 2));

                cyclePercentage += Time.deltaTime * _speed;
            }

            yield return null;
        }

        // Ends Function
        //_eventManager.SelectEvent();
        StopCoroutine(NightCycleController());
    }

    /// <summary>
    /// Pauses the time cycle
    /// </summary>
    public void PauseCycle()
    {
        _isPaused = true;
    }

    /// <summary>
    /// Resumes the current time cycle
    /// </summary>
    public void ResumeCycle()
    {
        _isPaused = false;
    }
}
