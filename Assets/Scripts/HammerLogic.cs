using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerLogic : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField]private AnvilCrafting anvil;
    [SerializeField] private ItemSlot anvilSlots;
    private bool justHit = false;
    private AudioSource _audio;
    [SerializeField] private AudioClip[] audioOptions;
    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audio = transform.GetChild(0).GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(!justHit)
        if(_rigidbody2D.velocity.magnitude>0.2f){
            if(_rigidbody2D.velocity.y<0){
                if(other.gameObject.tag == "Item"){
                    if(anvilSlots.connectedObjects.Count>0){
                        if(anvilSlots.connectedObjects.Contains(other.gameObject)){
                            anvil.smithTimer++;
                            GetComponent<MoveItem>().FlickMovement(new Vector3(0.6f, 1.4f), 0.2f);
                            justHit = true;
                            StartCoroutine(ResetJustHit());
                            _audio.clip = audioOptions[Random.Range(0,audioOptions.Length)];
                            _audio.pitch = 1+Random.Range(-0.1f,0.1f);
                            _audio.Play();
                        }
                    }
                }
            }
        }
    }
    private IEnumerator ResetJustHit(){
        yield return new WaitForSeconds(0.2f);
        justHit = false;
    }
}

