using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesManager : MonoBehaviour
{
    public static InteractablesManager main;

    [HideInInspector] public bool ObjectInteraction = false;

    private GameObject[] _interactableObjs;
    private Dictionary<InteractableTypes, InteractableObject> _interactablesDictionary;

    public enum InteractableTypes
    {
        NONE,
        MUSHROOM,
        FLASHLIGHT,
        AXE,
        BATTERIES,
        JUKEBOX,
        COMIC,
        SKULL,
        FIONARING,
        WATERBOTTLE,
        HARRYBOOKS
    }


    private void Awake()
    {
        if(main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _interactablesDictionary = new Dictionary<InteractableTypes, InteractableObject>();
        _interactableObjs = GameObject.FindGameObjectsWithTag("InteractableObj");

        foreach(GameObject obj in _interactableObjs)
        {
            _interactablesDictionary.Add(obj.GetComponent<InteractableObject>().InteractableType, obj.GetComponent<InteractableObject>());
            obj.SetActive(false);
        }
    }

    /// <summary>
    /// Checks to see if an object has been interacted with
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public bool CheckInteraction(InteractableTypes type)
    {
        if(_interactablesDictionary.TryGetValue(type, out InteractableObject interactableObject))
        {
            return interactableObject.HasBeenInteracted;
        }
        return false;
    }
}
