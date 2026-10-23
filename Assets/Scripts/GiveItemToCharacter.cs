using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GiveItemToCharacter : MonoBehaviour
{
    [SerializeField] private CharacterManager _characterManager;
    [SerializeField] private DialogueManager _dialogueManager;
    private GameObject objectOverWindow;
    public static GiveItemToCharacter Instance {get; private set;}
    [SerializeField] private Typer textTyper;
    private AudioSource _audio;
    [SerializeField] private AudioClip successSound, failSound;
    private void Start() {
        Instance = this;
        _audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(_characterManager.canGiveItems){
            if(other.gameObject.tag == "Item"){
                objectOverWindow = other.gameObject;
                other.GetComponent<MoveItem>().hoveringOverWindow = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(_characterManager.canGiveItems){
            if(other.gameObject.tag == "Item"){
                objectOverWindow = null;
                other.GetComponent<MoveItem>().hoveringOverWindow = false;
            }
        }
    }

    public void ReleaseItem(){
        DialogueHolder customer = _characterManager.CurrentCustomer;
        bool isCorrectItem = false;
        foreach(SmithingScriptableObj smth in customer.successObj){
            if(smth.noun == objectOverWindow.GetComponent<CardDisplay>().smithingObjInfo.noun){
                isCorrectItem = true;
            }
        }
        if(isCorrectItem){
            if(customer.successString.Length == 0 || objectOverWindow.GetComponent<CardDisplay>().smithingObjInfo.adjective.Contains(customer.successString)){
                //correct item given
                _characterManager.MakeCharacterLeave(true);
                textTyper.typeOut(_dialogueManager.ReadReaction("correct_item"));
                if(customer.pays){
                    ShopManager.Instance.SellItem(objectOverWindow.GetComponent<CardDisplay>().smithingObjInfo.sellPrice);
                }
                _audio.clip = successSound;
                _audio.Play();
            }
        }else{
            //incorrect item given
            _characterManager.MakeCharacterLeave(false);
            textTyper.typeOut(_dialogueManager.ReadReaction("wrong_item"));
            _audio.clip = failSound;
            _audio.Play();
        }
    }
}
