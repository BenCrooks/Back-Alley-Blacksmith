using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public static SlotManager Instance {get; private set;}
    [SerializeField] private GameObject anvilSlot, smelterSlot, furnaceSlot, /*morterSlot,*/ mouldSlot1, mouldSlot2, mouldSlot3;

    private void Start() {
        Instance = this;
    }
    public void ShowSpecificSlots(SmithingScriptableObj smthObj, GameObject whosAsking){
        if(smthObj.usedFor.HasFlag(ItemCategory.smithable)){
            if(anvilSlot.GetComponent<ItemSlot>().CheckSlot(whosAsking))
            anvilSlot.SetActive(true);
        }
        if(smthObj.usedFor.HasFlag(ItemCategory.smeltable)){
            if(smelterSlot.GetComponent<ItemSlot>().CheckSlot(whosAsking))
            smelterSlot.SetActive(true);
        }
        if(smthObj.usedFor.HasFlag(ItemCategory.furnacable)){
            if(furnaceSlot.GetComponent<ItemSlot>().CheckSlot(whosAsking))
            furnaceSlot.SetActive(true);
        }
        // if(smthObj.usedFor.HasFlag(ItemCategory.grindable)){
        //     if(morterSlot.GetComponent<ItemSlot>().CheckSlot(whosAsking))
        //     morterSlot.SetActive(true);
        // }
        if(smthObj.usedFor.HasFlag(ItemCategory.mouldable)){
            if(mouldSlot1.GetComponent<ItemSlot>().CheckSlot(whosAsking))
            mouldSlot1.SetActive(true);
            if(mouldSlot2.GetComponent<ItemSlot>().CheckSlot(whosAsking))
            mouldSlot2.SetActive(true);
            if(mouldSlot3.GetComponent<ItemSlot>().CheckSlot(whosAsking))
            mouldSlot3.SetActive(true);
        }
    }
    public void ShowAllSlots(){
        anvilSlot.SetActive(true);
        smelterSlot.SetActive(true); 
        furnaceSlot.SetActive(true); 
        // morterSlot.SetActive(true);
    }
    public void HideAllSlots(){
        StartCoroutine(HideNextFrame());
    }
    private IEnumerator HideNextFrame(){
        yield return new WaitForSeconds(0);
        anvilSlot.SetActive(false);
        smelterSlot.SetActive(false); 
        furnaceSlot.SetActive(false); 
        mouldSlot1.SetActive(false);
        mouldSlot2.SetActive(false);
        mouldSlot3.SetActive(false);
        // morterSlot.SetActive(false);
    }
}
