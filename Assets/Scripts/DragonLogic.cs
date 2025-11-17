using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonLogic : MonoBehaviour
{
    private bool clickedOn = false;
    [SerializeField] private GameObject dragonSleep, dragonBlowing;
    [SerializeField] private CoalLogic coal;
    private AudioSource _audio;
    private void Start() {
        _audio = GetComponent<AudioSource>();
    }
    private void OnMouseDown() {
        if(!clickedOn){
            clickedOn = true;
            dragonSleep.SetActive(false);
            dragonBlowing.SetActive(true);
            coal.SetHot();
            _audio.Play();
            StartCoroutine(ResetInSecs(1.6f));
        }
    }
    private IEnumerator ResetInSecs(float delayTime){
        yield return new WaitForSeconds(delayTime);
        coal.SetHot();
        clickedOn = false;
        dragonSleep.SetActive(true);
        dragonBlowing.SetActive(false);
    }
}
