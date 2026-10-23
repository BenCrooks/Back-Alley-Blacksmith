using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogue;
    private Dictionary<string, GameObject> customers = new Dictionary<string, GameObject>();
    private Dictionary<GameObject, Vector3> startPositions = new Dictionary<GameObject, Vector3>();
    private GameObject currentCharacter;
    [SerializeField] private float timeBetweenCharacters = 6, walkInTime=3;
    [HideInInspector] public bool canGiveItems;
    public DialogueHolder CurrentCustomer {get; private set;}

    private void Start() {
        foreach(Transform child in transform){
            DialogueHolder holder = child.GetComponent<DialogueHolder>();
            if(holder == null || string.IsNullOrEmpty(holder.inkKnot)){
                continue;
            }
            if(customers.ContainsKey(holder.inkKnot)){
                Debug.LogWarning($"{child.name} and {customers[holder.inkKnot].name} both use ink knot '{holder.inkKnot}', so only {customers[holder.inkKnot].name} will come in.", child);
                continue;
            }
            customers[holder.inkKnot] = child.gameObject;
            startPositions[child.gameObject] = child.position;
        }
        StartCoroutine(WaitAndTriggerNextCharacter());
    }

    public void TriggerNextCharacterDialogue(){
        CurrentCustomer = currentCharacter.GetComponent<DialogueHolder>();
        canGiveItems = false;
        _dialogue.StartConversation(CurrentCustomer.inkKnot);
    }

    public void TriggerNextDialogueCharacter(){
        StartCoroutine(WaitAndTriggerNextCharacter());
    }

    private IEnumerator WaitAndTriggerNextCharacter(){
        //the ink "customers" list decides who comes in next
        string knot = _dialogue.NextCustomerKnot();
        while(knot != null && !customers.ContainsKey(knot)){
            Debug.LogError($"No customer under CharacterManager has Ink Knot '{knot}', so they're skipped.", this);
            knot = _dialogue.NextCustomerKnot();
        }
        if(knot == null){
            //no customers left
            yield break;
        }
        yield return new WaitForSeconds(timeBetweenCharacters);
        float timer=0;
        currentCharacter = customers[knot];
        GameObject character = currentCharacter;
        //customers can come back, so always walk in from where they started
        character.transform.position = startPositions[character];
        character.SetActive(true);
        Vector3 startPos = character.transform.position;
        Vector3 endPos = new Vector3(transform.position.x, startPos.y, startPos.z);
        while(timer < walkInTime){
            timer += Time.deltaTime;
            character.transform.position = Vector3.Lerp(startPos, endPos, timer/walkInTime);
            yield return null;
        }
        TriggerNextCharacterDialogue();
    }
    public void MakeCharacterLeave(){
        StartCoroutine(WaitAndTriggerExit());
    }

    private IEnumerator WaitAndTriggerExit(){
        yield return new WaitForSeconds(3);
        _dialogue.TurnOffDialogue();
        float timer=0;
        GameObject character = currentCharacter;
        Vector3 endPos = character.transform.position + new Vector3(7f,0,0);
        Vector3 startPos = new Vector3(transform.position.x, endPos.y, endPos.z);
        while(timer < walkInTime){
            timer += Time.deltaTime;
            character.transform.position = Vector3.Lerp(startPos, endPos, timer/walkInTime);
            yield return null;
        }
        yield return null;
        character.transform.position = endPos;
        TriggerNextDialogueCharacter();
    }

}
