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
        //what they want comes from the tags on their ink deal line
        DialogueManager.Deal deal = _dialogueManager.CurrentDeal;
        SmithingScriptableObj given = objectOverWindow.GetComponent<CardDisplay>().smithingObjInfo;
        if(deal.Wants(given)){
            if(deal.mustBe.Length == 0 || given.adjective.Contains(deal.mustBe)){
                //correct item given
                _characterManager.MakeCharacterLeave();
                _dialogueManager.ShowReaction("correct_item");
                if(deal.pays){
                    ShopManager.Instance.SellItem(given.sellPrice);
                }
                _audio.clip = successSound;
                _audio.Play();
            }
        }else{
            //incorrect item given
            _characterManager.MakeCharacterLeave();
            _dialogueManager.ShowReaction("wrong_item");
            _audio.clip = failSound;
            _audio.Play();
        }
    }
}
