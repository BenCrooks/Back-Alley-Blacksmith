using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceCrafting : MonoBehaviour
{
    [SerializeField] private GameObject loadingBarParent, progressBar;
    [SerializeField] private recipe[] recipes;
    [SerializeField] private ItemSlot _itemSlot;
    private float craftingTimer;
    [SerializeField] private GameObject emptyItemCard;

    // Update is called once per frame
    void Update()
    {
        foreach(recipe rec in recipes){
            //has the same number
            List<SmithingScriptableObj> tempRec = new List<SmithingScriptableObj>();
            tempRec.AddRange(rec.input);
            if(_itemSlot.connectedObjects.Count == rec.input.Count){
                foreach(GameObject g in _itemSlot.connectedObjects){
                    SmithingScriptableObj smithObj = g.GetComponent<CardDisplay>().smithingObjInfo;
                    if(tempRec.Contains(smithObj)){
                        tempRec.Remove(smithObj);
                    }else{
                        continue;
                    }
                    if(tempRec.Count == 0){
                        //found all items, you can craft now
                        if(CanCraft(rec)){
                            SpawnItems(rec);
                            return;
                        }
                    }
                }
            }
        }
        if(craftingTimer==0){
            loadingBarParent.SetActive(false);
        }
    }
    private bool CanCraft(recipe rec){
        craftingTimer += Time.deltaTime;
        loadingBarParent.SetActive(true);
        progressBar.transform.localScale = new Vector3(craftingTimer/rec.craftTime, progressBar.transform.localScale.y,progressBar.transform.localScale.z);
        if(craftingTimer>rec.craftTime){
            craftingTimer=0;
            return true;
        }
        return false;
    }
    private void SpawnItems(recipe rec){
        for(int i=0; i< rec.outPut.Count; i++){
            GameObject newItem = Instantiate(emptyItemCard,_itemSlot.connectedObjects[i].transform.position, Quaternion.identity);
            newItem.GetComponent<CardDisplay>().smithingObjInfo = rec.outPut[i];
        }
        List<GameObject> conObj = new List<GameObject>();
        conObj.AddRange(_itemSlot.connectedObjects);
        foreach(GameObject g2 in conObj){
            _itemSlot.RemoveFromSlot(g2, true);
        }
    }
}
