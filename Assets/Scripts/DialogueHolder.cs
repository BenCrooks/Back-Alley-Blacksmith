using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueHolder : MonoBehaviour
{
    public DialogueScriptableObj dialogue;
    public string dialogueOnSuccess, dialogueOnFailure;
    public UnityEvent onEndDialogueSuccessfully, onEndDialogueFail;
    public SmithingScriptableObj[] successObj;
    public string successString="";
    public String GoalSummary;
    public bool pays = true;
    public SmithingScriptableObj[] giveOnDialogueSuccess;
}
