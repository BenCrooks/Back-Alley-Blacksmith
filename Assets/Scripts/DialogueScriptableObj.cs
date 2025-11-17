using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class DialogueScriptableObj : ScriptableObject
{
    public string dialogue;
    public string dialogueResponse1, dialogueResponse2, dialogueResponse3;
    public DialogueScriptableObj nextDialogue1, nextDialogue2, nextdialogue3;
}
