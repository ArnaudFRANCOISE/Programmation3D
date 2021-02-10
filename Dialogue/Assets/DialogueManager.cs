using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue;
    [SerializeField] private TextMeshProUGUI Script;
    [SerializeField] private TextMeshProUGUI charactername; 
    
    private Queue<string> sentences;
    private int alternate_character = 0; // counter allowing us to change character

// Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        
    }

    // Launch with the "Start conversation" button
    public void StartDialogue()
    {
        //Debug.Log("Starting conversation with " + dialogue.name);
        // Display charactername in the corresponding textbox
        charactername.text = _dialogue.character1_string;
        sentences.Clear();
        
        //int i = 0;
        foreach (string sentence in _dialogue.List_of_sentence)
        {
            sentences.Enqueue(sentence);
            //Debug.Log(sentence);
            //Debug.Log(sentences.Count);
            //i++;
        }
        DisplayNextSentence();
    }
    // launch with the [continue] button
    public void DisplayNextSentence()
    {
 
        
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        string sentence_to_display = sentences.Dequeue();
        
        //
        if (alternate_character % 2 == 0) //alternating between character 
        {
            charactername.text = _dialogue.character1_string;
        }
        else
        {
            charactername.text = _dialogue.character2_string;
        }
        // Display the script on the coresponding Textbox
        Script.text = sentence_to_display;
        
        Debug.Log(sentences.Count);
        
        Debug.Log(sentence_to_display);
        //Debug.Log(("FLAG"));
        alternate_character++;
    }
    void EndDialogue()
    {
        Debug.Log("end of conv");
        Script.text = "[End of conversation]";
    }

}