using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOutside : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprRen;
    [SerializeField] private float fadeSpeed = 0.2f;
    private Color startCol = Color.white, endCol = new Color(1,1,1,0);
    private Coroutine fadeRoutine;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Item"){
            if(fadeRoutine!=null){
                StopCoroutine(fadeRoutine);
            }
            fadeRoutine = StartCoroutine(FadeOut());
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Item"){
            if(fadeRoutine!=null){
                StopCoroutine(fadeRoutine);
            }
            fadeRoutine = StartCoroutine(FadeIn());
        }
    }
    private IEnumerator FadeOut(){
        Color startColor = _sprRen.color;
        float timer=0;
        while(timer<fadeSpeed){
            timer+=Time.deltaTime;
            _sprRen.color = Color.Lerp(startColor, endCol, timer/fadeSpeed);
            yield return null;
        }
        _sprRen.color = endCol;
    }
    private IEnumerator FadeIn(){
        Color startColor = _sprRen.color;
        float timer=0;
        while(timer<fadeSpeed){
            timer+=Time.deltaTime;
            _sprRen.color = Color.Lerp(startColor, startCol, timer/fadeSpeed);
            yield return null;
        }
        _sprRen.color = startCol;
    }
}
