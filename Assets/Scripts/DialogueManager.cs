using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using Ink.UnityIntegration;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    //what a customer agreed to buy, read from the tags on their ink deal line
    public class Deal
    {
        public List<string> wantedNouns = new List<string>();
        public string mustBe = "";
        public bool pays = true;
        public List<SmithingScriptableObj> gives = new List<SmithingScriptableObj>();

        public bool Wants(SmithingScriptableObj item){
            return wantedNouns.Contains(Simplify(item.noun));
        }
    }

    [SerializeField] private InkFile inkStory;
    [Tooltip("Every item the ink story can name in #wants or #gives. Right-click this component > Find All Items to refresh it.")]
    [SerializeField] private List<SmithingScriptableObj> items = new List<SmithingScriptableObj>();
    [SerializeField] private CharacterManager _characters;
    [SerializeField] private List<GameObject> talking;
    private List<Typer> textTypers = new List<Typer>();
    [SerializeField] private List<DialogueOption> responses;
    [SerializeField] private GameObject emptyItemCard;
    [SerializeField] private Transform cardSpawnPoint;

    private const string QueueKnot = "customers", QueueFlow = "customer_queue";
    private Story _story;
    private string currentKnot;
    private bool dealMade, itemsGiven, gameOver, queueStarted;
    public Deal CurrentDeal {get; private set;}

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

    //the next knot in the ink "customers" list, or null once nobody is left
    public string NextCustomerKnot(){
        if(gameOver){
            return null;
        }
        //the queue runs in its own ink flow so it keeps its place between conversations
        _story.SwitchFlow(QueueFlow);
        if(!queueStarted){
            _story.ChoosePathString(QueueKnot);
            queueStarted = true;
        }
        string knot = null;
        while(knot == null && _story.canContinue){
            string line = _story.Continue().Trim();
            if(line.Length>0){
                knot = line;
            }
        }
        _story.SwitchToDefaultFlow();
        return knot;
    }

    public void StartConversation(string knot){
        currentKnot = knot;
        dealMade = false;
        itemsGiven = false;
        CurrentDeal = null;
        _story.ChoosePathString(knot);
        ShowNextLine();
    }

    //called by the response buttons
    public void ShowNextDialogue(int chosenDialogue){
        _story.ChooseChoiceIndex(chosenDialogue);
        ShowNextLine();
    }

    //the customer's reaction once they're handed an item: "correct_item" or "wrong_item"
    public void ShowReaction(string stitch){
        _story.ChoosePathString(currentKnot + "." + stitch);
        string reaction = ReadLines(out _);
        if(reaction.Length==0){
            TurnOffDialogue();
        }else{
            ShowLine(reaction);
        }
    }

    private void ShowNextLine(){
        string nextDialogue = ReadLines(out List<string> tags);
        if(tags.Contains("deal")){
            dealMade = true;
            CurrentDeal = ReadDeal(tags);
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
        ShowLine(nextDialogue);
    }

    //types a line into the speech bubble that fits it
    private void ShowLine(string text){
        TurnOffDialogue();
        int objTalking = 0;
        if(text.Length>75){
            objTalking=2;
        }else if(text.Length>45){
            objTalking=1;
        }
        talking[objTalking].SetActive(true);
        textTypers[objTalking].typeOut(text);
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

    //tags look like "wants: Iron Sword, Steel Sword", "must_be: Magic", "gives: Magic Powder" and "free"
    private Deal ReadDeal(List<string> tags){
        Deal deal = new Deal();
        foreach(string tag in tags){
            int colon = tag.IndexOf(':');
            string key = (colon<0 ? tag : tag.Substring(0, colon)).Trim().ToLowerInvariant();
            string value = colon<0 ? "" : tag.Substring(colon+1).Trim();
            if(key == "wants"){
                foreach(string name in SplitList(value)){
                    SmithingScriptableObj item = FindItem(name);
                    if(item == null){
                        Debug.LogWarning($"ink knot '{currentKnot}' wants '{name}', which isn't in DialogueManager's item list.", this);
                    }
                    deal.wantedNouns.Add(Simplify(item != null ? item.noun : name));
                }
            }else if(key == "gives"){
                foreach(string name in SplitList(value)){
                    SmithingScriptableObj item = FindItem(name);
                    if(item == null){
                        Debug.LogWarning($"ink knot '{currentKnot}' gives '{name}', which isn't in DialogueManager's item list.", this);
                    }else{
                        deal.gives.Add(item);
                    }
                }
            }else if(key == "must_be"){
                deal.mustBe = value;
            }else if(key == "free"){
                deal.pays = false;
            }
        }
        if(deal.wantedNouns.Count == 0){
            Debug.LogWarning($"ink knot '{currentKnot}' made a deal with no #wants tag, so no item will satisfy them.", this);
        }
        return deal;
    }

    //finds an item by asset name, noun or adjective + noun, ignoring case and spaces
    public SmithingScriptableObj FindItem(string name){
        string key = Simplify(name);
        foreach(SmithingScriptableObj item in items){
            if(item != null && (Simplify(item.name) == key || Simplify(item.noun) == key || Simplify(item.adjective + item.noun) == key)){
                return item;
            }
        }
        return null;
    }

    private static string Simplify(string name){
        return new string(name.Where(char.IsLetterOrDigit).Select(char.ToLowerInvariant).ToArray());
    }

    private static IEnumerable<string> SplitList(string value){
        return value.Split(',').Select(s => s.Trim()).Where(s => s.Length>0);
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
                foreach(SmithingScriptableObj item in CurrentDeal.gives){
                    GameObject newItem = Instantiate(emptyItemCard, cardSpawnPoint.position, Quaternion.identity);
                    newItem.GetComponent<CardDisplay>().smithingObjInfo = item;
                }
            }
        }else if(_story.currentChoices.Count == 0){
            //conversation over without a deal
            if(!gameOver){
                _characters.MakeCharacterLeave();
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

#if UNITY_EDITOR
    [ContextMenu("Find All Items")]
    public void FindAllItems(){
        items.Clear();
        foreach(string guid in UnityEditor.AssetDatabase.FindAssets("t:SmithingScriptableObj")){
            items.Add(UnityEditor.AssetDatabase.LoadAssetAtPath<SmithingScriptableObj>(UnityEditor.AssetDatabase.GUIDToAssetPath(guid)));
        }
        UnityEditor.EditorUtility.SetDirty(this);
    }
#endif
}
