using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueHolder : MonoBehaviour
{
    [Tooltip("Knot in Assets/Dialogue/BackAlleyBlacksmith.ink where this customer's conversation starts")]
    public string inkKnot;
    public UnityEvent onEndDialogueSuccessfully, onEndDialogueFail;
    public SmithingScriptableObj[] successObj;
    public string successString="";
    public bool pays = true;
    public SmithingScriptableObj[] giveOnDialogueSuccess;
}
