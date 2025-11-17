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
        bool isCorrectItem = false;
        foreach(SmithingScriptableObj smth in _characterManager.successOptions){
            if(smth.noun == objectOverWindow.GetComponent<CardDisplay>().smithingObjInfo.noun){
                isCorrectItem = true;
            }
        }
        if(isCorrectItem){
            if(_characterManager.successAdjective.Length == 0 || objectOverWindow.GetComponent<CardDisplay>().smithingObjInfo.adjective.Contains(_characterManager.successAdjective)){
                //correct item given
                _characterManager.MakeCharacterLeave(true);
                textTyper.typeOut(_characterManager.dialogueOnSuccess);
                if(_characterManager.pays){
                    ShopManager.Instance.SellItem(objectOverWindow.GetComponent<CardDisplay>().smithingObjInfo.sellPrice);
                }
                _audio.clip = successSound;
                _audio.Play();
            }
        }else{
            //incorrect item given
            _characterManager.MakeCharacterLeave(false);
            textTyper.typeOut(_characterManager.dialogueOnFailure);
            _audio.clip = failSound;
            _audio.Play();
        }
    }
}
