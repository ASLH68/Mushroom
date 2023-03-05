using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCClass : MonoBehaviour
{
    protected string _name;

    [Range(-50, 50)]
    protected int _emotionalState;

    protected bool _isInteractable;

    public string Name => name;
    public bool IsInteractable => _isInteractable;

    private void Start()
    {
        _isInteractable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player") && _isInteractable)
        {
            DialogueUIController.main.ShowInteractKey();
            DialogueUIController.main.SetCanTalk(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Player") && _isInteractable)
        {
            DialogueUIController.main.HideInteractKey();
            DialogueUIController.main.SetCanTalk(false);
        }
    }
}
