using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogueOption : MonoBehaviour
{
    private SpriteRenderer _sprRen;
    [SerializeField] private Color startColor, hoverColor, clickColor;
    private bool isClickable = false;
    [SerializeField] private UnityEvent triggerButtonEvent;
    private bool waitingToTurnOff = false;
    private void Start() {
        _sprRen = GetComponent<SpriteRenderer>();
        MakeInactive();
    }
    void OnMouseEnter()
    {
        if(isClickable){
            _sprRen.color = hoverColor;
        }
    }

    // ...the red fades out to cyan as the mouse is held over...
    // void OnMouseOver()
    // {
    //     print("over");
    // }

    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
        if(isClickable){
            ReturnToOriginalColor();
        }
    }
    public void ReturnToOriginalColor(){
        _sprRen.color = startColor;
    }
    void OnMouseDown() {
        if(isClickable){
            triggerButtonEvent.Invoke();
        }
    }
    public void Clicked(){
        _sprRen.color = clickColor;
        isClickable = false;
        StartCoroutine(TurnOffInTime());
    }

    private IEnumerator TurnOffInTime(){
        waitingToTurnOff = true;
        yield return new WaitForSeconds(3);
        if(waitingToTurnOff){
            MakeInactive();
        }
    }
    public void MakeInactive(){
        isClickable = false;
        _sprRen.enabled = false;
        transform.parent.GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void SetText(string text){
        transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = text;
    }
    public void MakeActive(){
        isClickable = true;
        _sprRen.enabled = true;
        transform.parent.GetComponent<SpriteRenderer>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
        waitingToTurnOff = false;
    }

    public void MakeInactiveForSecond(float time){
        MakeInactive();
        StartCoroutine(ReEnableInSecs(time));
    }
    private IEnumerator ReEnableInSecs(float time){
        yield return new WaitForSeconds(time);
        MakeActive();
    }
}
