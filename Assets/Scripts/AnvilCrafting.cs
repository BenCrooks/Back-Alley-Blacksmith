using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnvilCrafting : MonoBehaviour
{
    [SerializeField] private GameObject loadingBarParent, progressBar;
    [SerializeField] private recipe[] recipes;
    [SerializeField] private ItemSlot _itemSlot;
    [SerializeField] private GameObject emptyItemCard;
    [HideInInspector] public float smithTimer;

    // Update is called once per frame
    void Update()
    {
        foreach(recipe rec in recipes){
            //has the same number
            List<string> tempRec = new List<string>();
            foreach(SmithingScriptableObj smth in rec.input){
                tempRec.Add(smth.noun);
            }            
            if(_itemSlot.connectedObjects.Count == rec.input.Count){
                foreach(GameObject g in _itemSlot.connectedObjects){
                    SmithingScriptableObj smithObj = g.GetComponent<CardDisplay>().smithingObjInfo;
                    if(tempRec.Contains(smithObj.noun)){
                        tempRec.Remove(smithObj.noun);
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
        if(smithTimer == 0){
            loadingBarParent.SetActive(false);
        }
    }
    private bool CanCraft(recipe rec){
        loadingBarParent.SetActive(true);
        progressBar.transform.localScale = new Vector3(smithTimer/rec.craftTime,progressBar.transform.localScale.y,progressBar.transform.localScale.z);

        if(smithTimer>=rec.craftTime){
            smithTimer = 0;
            loadingBarParent.SetActive(false);
            return true;
        }
        return false;
    }
    private void SpawnItems(recipe rec){
        string adjective = "";
        SmithingScriptableObj sameObj = rec.input[0];
        foreach(GameObject smthObj in _itemSlot.connectedObjects){
            SmithingScriptableObj smth = smthObj.GetComponent<CardDisplay>().smithingObjInfo;
            if(smth.adjective.Length>0){
                adjective += smth.adjective + " ";
            }else{
                sameObj = smth;
            }
        }

        if(rec.outPut.Count > 0){
            for(int i=0; i< rec.outPut.Count; i++){
                GameObject newItem = Instantiate(emptyItemCard,_itemSlot.connectedObjects[i].transform.position, Quaternion.identity);
                SmithingScriptableObj tempOutputSmth = SmithingScriptableObj.CreateInstance(rec.outPut[i].sprite, rec.outPut[i]._color, rec.outPut[i].noun, adjective, rec.outPut[i].description, rec.outPut[i].usedFor, rec.outPut[i].cost, rec.outPut[i].sellPrice);
                tempOutputSmth.adjective = adjective;
                newItem.GetComponent<CardDisplay>().smithingObjInfo = tempOutputSmth;
            }
        }else{
            GameObject newItem = Instantiate(emptyItemCard,_itemSlot.connectedObjects[0].transform.position, Quaternion.identity);
            SmithingScriptableObj tempOutputSmth = SmithingScriptableObj.CreateInstance(sameObj.sprite, sameObj._color, sameObj.noun, adjective, sameObj.description, sameObj.usedFor, sameObj.cost, sameObj.sellPrice);
            tempOutputSmth.adjective = adjective;
            newItem.GetComponent<CardDisplay>().smithingObjInfo = tempOutputSmth;
        }
        List<GameObject> conObj = new List<GameObject>();
        conObj.AddRange(_itemSlot.connectedObjects);
        foreach(GameObject g2 in conObj){
            _itemSlot.RemoveFromSlot(g2, true);
        }
    }
}
