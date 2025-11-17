using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private CharacterManager _characters;
    [SerializeField] private List<GameObject> talking;
    private List<Typer> textTypers = new List<Typer>();
    [SerializeField] private List<DialogueOption> responses;
    public DialogueScriptableObj currentDialogue;
    [SerializeField] private GameObject emptyItemCard;
    [SerializeField] private Transform cardSpawnPoint;

    private void Awake() {
        foreach(GameObject talker in talking){
            textTypers.Add(talker.transform.GetChild(0).GetComponent<Typer>());
        }
    }

    public void ShowNextDialogue(int chosenDialogue){
        if(chosenDialogue==0){
            currentDialogue = currentDialogue.nextDialogue1;
        }else if(chosenDialogue==1){
            currentDialogue = currentDialogue.nextDialogue2;
        }else if(chosenDialogue==2){
            currentDialogue = currentDialogue.nextdialogue3;
        }
        string nextDialogue = currentDialogue.dialogue;
        talking[0].SetActive(false);
        talking[1].SetActive(false);
        talking[2].SetActive(false);
        if(nextDialogue.Length<=0){
            //leave with success
            _characters.canGiveItems = true;
            nextDialogue = _characters.overallGoal;
            // nextDialogue = _characters.dialogueOnSuccess;
        }
        int objTalking = 0;
        if(nextDialogue.Length>75){
            objTalking=2;
        }else if(nextDialogue.Length>45){
            objTalking=1;
        }
        talking[objTalking].SetActive(true);
        if(nextDialogue.Length>0){
            textTypers[objTalking].typeOut(nextDialogue);
        }else{
            print("no dialogue?");
        }
    }
    public void TurnOffDialogue(){
        talking[0].SetActive(false);
        talking[1].SetActive(false);
        talking[2].SetActive(false);
    }
    public void ShowDialogueOptions(){
        if(!_characters.canGiveItems){
            if(currentDialogue.dialogueResponse1 == ""){
                //dialogue fail
                _characters.MakeCharacterLeave(false);
            }else{
                List<string> options = new List<string>
                {
                    currentDialogue.dialogueResponse1,
                    currentDialogue.dialogueResponse2,
                    currentDialogue.dialogueResponse3
                };
                for(int i=0; i< responses.Count; i++){
                    responses[i].MakeActive();
                    responses[i].ReturnToOriginalColor();
                    responses[i].SetText(options[i]);
                }
            }
        }else{
            if(_characters.giveItems.Length > 0){
                foreach(SmithingScriptableObj item in _characters.giveItems){
                    GameObject newItem = Instantiate(emptyItemCard, cardSpawnPoint.position, Quaternion.identity);
                    newItem.GetComponent<CardDisplay>().smithingObjInfo = item;
                }
                _characters.giveItems = new SmithingScriptableObj[0];
            }
        }
    }
}
