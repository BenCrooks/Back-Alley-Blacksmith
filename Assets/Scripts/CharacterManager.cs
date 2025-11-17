using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogue;
    private List<GameObject> characters = new List<GameObject>();
    private int currentCharacter = -1;
    [SerializeField] private float timeBetweenCharacters = 6, walkInTime=3;
    public string dialogueOnSuccess, dialogueOnFailure;
    [HideInInspector] public SmithingScriptableObj[] successOptions, giveItems;
    [HideInInspector] public string successAdjective;
    [HideInInspector] public bool canGiveItems, pays;
    [HideInInspector] public string overallGoal;
    
    
    private void Start() {
        foreach(Transform child in transform){
            characters.Add(child.gameObject);
        }
        StartCoroutine(WaitAndTriggerNextCharacter());
    }

    public void TriggerNextCharacterDialogue(){
        DialogueHolder currentCharacterDialogue = characters[currentCharacter].GetComponent<DialogueHolder>();
        dialogueOnSuccess = currentCharacterDialogue.dialogueOnSuccess;
        dialogueOnFailure = currentCharacterDialogue.dialogueOnFailure;
        _dialogue.currentDialogue = currentCharacterDialogue.dialogue;
        successOptions = currentCharacterDialogue.successObj;
        successAdjective = currentCharacterDialogue.successString;
        overallGoal = currentCharacterDialogue.GoalSummary;
        pays = currentCharacterDialogue.pays;
        giveItems = currentCharacterDialogue.giveOnDialogueSuccess;
        
        _dialogue.ShowNextDialogue(-1);
        canGiveItems = false;
    }

    public void TriggerNextDialogueCharacter(){
        StartCoroutine(WaitAndTriggerNextCharacter());
    }

    private IEnumerator WaitAndTriggerNextCharacter(){
        currentCharacter ++;
        while(!characters[currentCharacter].activeSelf){
            currentCharacter ++;
        }
        yield return new WaitForSeconds(timeBetweenCharacters);
        float timer=0;
        GameObject character = characters[currentCharacter];
        Vector3 startPos = character.transform.position;
        Vector3 endPos = new Vector3(transform.position.x, startPos.y, startPos.z);
        while(timer < walkInTime){
            timer += Time.deltaTime;
            characters[currentCharacter].transform.position = Vector3.Lerp(startPos, endPos, timer/walkInTime);
            yield return null;
        }
        TriggerNextCharacterDialogue();
    }
    public void MakeCharacterLeave(bool success){
        StartCoroutine(WaitAndTriggerExit(success));
    }

    private IEnumerator WaitAndTriggerExit(bool success){
        yield return new WaitForSeconds(3);
        _dialogue.TurnOffDialogue();
        if(success){
            characters[currentCharacter].GetComponent<DialogueHolder>().onEndDialogueSuccessfully.Invoke();
        }else{
            characters[currentCharacter].GetComponent<DialogueHolder>().onEndDialogueFail.Invoke();
        }
        float timer=0;
        GameObject character = characters[currentCharacter];
        Vector3 endPos = character.transform.position + new Vector3(7f,0,0);
        Vector3 startPos = new Vector3(transform.position.x, endPos.y, endPos.z);
        while(timer < walkInTime){
            timer += Time.deltaTime;
            characters[currentCharacter].transform.position = Vector3.Lerp(startPos, endPos, timer/walkInTime);
            yield return null;
        }    
        yield return null;
        characters[currentCharacter].transform.position = endPos;
        TriggerNextDialogueCharacter();
    }

}
