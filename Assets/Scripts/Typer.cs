using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Typer : MonoBehaviour
{
    private TextMeshPro tmp;
    private string AllText;
    private Coroutine typeCoroutine;
    private float typeTime = 0.05f;
    //goes 1: symbolToDefine, 2:style, 3: closeStyle
    [SerializeField] private List<string> styleSymbols, styleStyleOpen, styleStyleClose;
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private AudioSource _audio;
    
    // Start is called before the first frame update
    void Start()
    {
        tmp = transform.GetChild(0).GetComponent<TextMeshPro>();
    }
    public float typeOut(string texty){
        if(tmp == null){
            tmp = transform.GetChild(0).GetComponent<TextMeshPro>();
        }
        tmp.text = "";
        AllText = texty;
        typeCoroutine = StartCoroutine(Typewriter(texty));
        return texty.Length*typeTime;
    }

    public void finishText(){
        if(typeCoroutine!=null){
            StopCoroutine(typeCoroutine);
        }
        tmp.text = AllText;
    }
    IEnumerator Typewriter(string text)
    {
        var waitTimer = new WaitForSeconds(typeTime);
        string closeStyle = "";
        bool appliedStyle = false;
        for(int i =0; i<text.Length;i++)
        {
            char c = text[i];
            string tempText = c.ToString();
            if(styleSymbols.Contains(c.ToString())){
                if(!appliedStyle){
                    //set a style
                    for(int symbolInt = 0; symbolInt< styleSymbols.Count; symbolInt++){
                        if(styleSymbols[symbolInt] == c.ToString()){
                            tempText = styleStyleOpen[symbolInt];
                            closeStyle = styleStyleClose[symbolInt];
                            // for(int j=i+1; j<text.Length; j++){
                            //     tempText = tempText + text[j];
                            //     if(text[j].ToString() == ">"){
                            //         i=j;
                            //         tempText = tempText + text[j+1];
                            //         j = text.Length + 1;
                            //     }
                            // }
                        }
                    }
                }else{
                    tempText = "";
                    appliedStyle = false;
                }
            }
            if(appliedStyle){
                tmp.text = tmp.text.Remove(tmp.text.Length - closeStyle.Length) + tempText + closeStyle;
            }else{
                if(closeStyle!=""){
                    appliedStyle = true;
                    tmp.text = tmp.text + tempText + closeStyle;
                }else{
                    tmp.text = tmp.text + tempText;
                }
            }
            _audio.pitch = Random.Range(0.9f,1.1f);
            _audio.volume = Random.Range(0.05f, 0.11f);
            _audio.Play();
            yield return waitTimer;
        }
        _dialogueManager.ShowDialogueOptions();
    }
}
