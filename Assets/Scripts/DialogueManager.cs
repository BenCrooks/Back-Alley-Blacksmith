using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using Ink.UnityIntegration;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private InkFile inkStory;
    [SerializeField] private CharacterManager _characters;
    [SerializeField] private List<GameObject> talking;
    private List<Typer> textTypers = new List<Typer>();
    [SerializeField] private List<DialogueOption> responses;
    [SerializeField] private GameObject emptyItemCard;
    [SerializeField] private Transform cardSpawnPoint;

    private Story _story;
    private string currentKnot;
    private bool dealMade, itemsGiven, gameOver;

    private void Awake() {
        foreach(GameObject talker in talking){
            textTypers.Add(talker.transform.GetChild(0).GetComponent<Typer>());
        }
        if(inkStory == null || !inkStory.isCompiled){
            Debug.LogError("DialogueManager needs the compiled ink story: drag Assets/Dialogue/BackAlleyBlacksmith.ink onto its Ink Story field.", this);
            return;
        }
        _story = new Story(inkStory.storyJson);
    }

    public void StartConversation(string knot){
        currentKnot = knot;
        dealMade = false;
        itemsGiven = false;
        _story.ChoosePathString(knot);
        ShowNextLine();
    }

    //called by the response buttons
    public void ShowNextDialogue(int chosenDialogue){
        _story.ChooseChoiceIndex(chosenDialogue);
        ShowNextLine();
    }

    //the customer's reaction once they're handed an item: "correct_item" or "wrong_item"
    public string ReadReaction(string stitch){
        _story.ChoosePathString(currentKnot + "." + stitch);
        return ReadLines(out _);
    }

    private void ShowNextLine(){
        string nextDialogue = ReadLines(out List<string> tags);
        if(tags.Contains("deal")){
            dealMade = true;
            _characters.canGiveItems = true;
        }
        if(tags.Contains("game_over")){
            gameOver = true;
        }
        if(nextDialogue.Length==0){
            //nothing new to say, keep the last bubble up
            ShowDialogueOptions();
            return;
        }
        TurnOffDialogue();
        int objTalking = 0;
        if(nextDialogue.Length>75){
            objTalking=2;
        }else if(nextDialogue.Length>45){
            objTalking=1;
        }
        talking[objTalking].SetActive(true);
        textTypers[objTalking].typeOut(nextDialogue);
    }

    //runs the story until it waits for a choice or ends, one bubble's worth of text
    private string ReadLines(out List<string> tags){
        tags = new List<string>();
        List<string> lines = new List<string>();
        while(_story.canContinue){
            string line = _story.Continue().Trim();
            if(line.Length>0){
                lines.Add(line);
            }
            tags.AddRange(_story.currentTags);
        }
        return string.Join("\n", lines);
    }

    public void TurnOffDialogue(){
        talking[0].SetActive(false);
        talking[1].SetActive(false);
        talking[2].SetActive(false);
    }

    //called by the Typer once a line has finished typing
    public void ShowDialogueOptions(){
        if(dealMade){
            if(!itemsGiven){
                itemsGiven = true;
                foreach(SmithingScriptableObj item in _characters.CurrentCustomer.giveOnDialogueSuccess){
                    GameObject newItem = Instantiate(emptyItemCard, cardSpawnPoint.position, Quaternion.identity);
                    newItem.GetComponent<CardDisplay>().smithingObjInfo = item;
                }
            }
        }else if(_story.currentChoices.Count == 0){
            //conversation over without a deal
            if(!gameOver){
                _characters.MakeCharacterLeave(false);
            }
        }else{
            if(_story.currentChoices.Count > responses.Count){
                Debug.LogWarning($"ink knot '{currentKnot}' offers {_story.currentChoices.Count} choices but there are only {responses.Count} response buttons.");
            }
            for(int i=0; i< responses.Count; i++){
                if(i < _story.currentChoices.Count){
                    responses[i].MakeActive();
                    responses[i].ReturnToOriginalColor();
                    responses[i].SetText(_story.currentChoices[i].text);
                }else{
                    responses[i].MakeInactive();
                }
            }
        }
    }
}
