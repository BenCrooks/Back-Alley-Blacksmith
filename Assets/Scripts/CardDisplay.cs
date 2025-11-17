using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    public SmithingScriptableObj smithingObjInfo;
    [SerializeField] private TextMeshPro cardName, cardDescription;
    [SerializeField] private SpriteRenderer cardImage;
    // Start is called before the first frame update
    void Start()
    {
        //example smelly flaming ingot
        if(cardName!=null)
        cardName.text = smithingObjInfo.adjective+" " + smithingObjInfo.noun;
        if(cardDescription!=null)
        cardDescription.text = smithingObjInfo.description;
        if(cardImage!=null){
            cardImage.sprite = smithingObjInfo.sprite;
            cardImage.color = smithingObjInfo._color;
        }
    }
}
