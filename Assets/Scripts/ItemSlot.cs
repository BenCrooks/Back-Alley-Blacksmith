using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private int carryAmount = 1;
    [HideInInspector] public List<GameObject> connectedObjects = new List<GameObject>();

    public void AttachToSlot(GameObject go){
        if(!connectedObjects.Contains(go)){
            if(connectedObjects.Count < carryAmount){
                connectedObjects.Add(go);
            }
        }
    }
    public bool CheckSlot(GameObject objectInSlot){
        if(connectedObjects.Count < carryAmount || connectedObjects.Contains(objectInSlot)){
            return true;
        }
        return false;
    }
    public void RemoveFromSlot(GameObject go, bool destroyAfter = false){
        if(connectedObjects.Contains(go)){
            if(connectedObjects.Count>0){
                connectedObjects.Remove(go);
                if(destroyAfter){
                    Destroy(go);
                }
            }
        }
    }
}
