using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager main;
    private GameObject[] NPCObjects;
    private Dictionary<string, NPCClass> NPCDictionary;

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
        NPCObjects = GameObject.FindGameObjectsWithTag("Character");

        foreach(GameObject obj in NPCObjects)
        {
            NPCDictionary.Add(obj.GetComponent<NPCClass>().Name, obj.GetComponent<NPCClass>());
        }
    }
}
