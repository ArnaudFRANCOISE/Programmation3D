using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;
    
    //Trigger Dialogue - get the StartDialogue methode in the 
    //dialogue Manager
    public void TriggerDialogue()
    {
        _dialogueManager.StartDialogue();
        
    }
}
