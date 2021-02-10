using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new_dialogue", menuName = "new_dialogue")]


public class Dialogue : ScriptableObject
{
    [SerializeField] private string character_name1;
    [SerializeField] private string character_name2;
    [TextArea(3, 10)] [SerializeField] private List<string> list_of_sentence;
    
    public string character1_string => character_name1;
    public string character2_string => character_name2;
    public List<string> List_of_sentence => list_of_sentence;
}