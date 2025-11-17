using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SmithingObj", menuName = "ScriptableObjects/SmithingScriptableObj", order = 1)]
public class SmithingScriptableObj : ScriptableObject
{
    public Sprite sprite;
    public Color _color; 
    public string noun, adjective, description;
    public ItemCategory usedFor;
    public int cost;
    public int sellPrice;

    public void Init(Sprite sprite, Color _color, string noun,string adjective,string description, ItemCategory usedfor, int cost, int sellPrice)
   {
        this.sprite = sprite;
        this._color = _color;
        this.noun = noun;
        this.adjective = adjective;
        this.description = description;
        this.usedFor = usedfor;
        this.cost = cost;
        this.sellPrice = sellPrice;

   }

   public static SmithingScriptableObj CreateInstance(Sprite sprite, Color _color, string noun,string adjective,string description, ItemCategory usedfor, int cost, int sellPrice)
   {
      var data = ScriptableObject.CreateInstance<SmithingScriptableObj>();
      data.Init(sprite, _color, noun, adjective, description, usedfor, cost, sellPrice);
      return data;
   }

}
[Flags]
public enum ItemCategory{
    smeltable = 1<<1, 
    smithable = 1<<2, 
    mouldable = 1<<3, 
    furnacable = 1<<4
}


[Serializable]
public class recipe{
    public List<SmithingScriptableObj> input;
    public float craftTime;
    public List<SmithingScriptableObj> outPut;
}



