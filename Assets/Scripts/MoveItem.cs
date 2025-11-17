using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Tween;
using Unity.VisualScripting;

public class MoveItem : MonoBehaviour
{
    private bool clickedOn =false, inSlot = false;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _boxCol;
    [SerializeField] private float tweenPickUpSpeed;
    [SerializeField] private float tweenPickUpScaleMid, tweenPickUpScaleEnd;
    private Vector3 startScale;
    private float moveRotation;
    [SerializeField]private float rotationMomentum = 8f, rotationCap = 45f, rotationMulti = 8;
    private DisplayItemInfo _info;
    [SerializeField] private bool turnOffCollision = true, horizontalMovementShift = true;
    private GameObject currentSlot;
    private bool destroyed = false;
    [HideInInspector] public bool isShopItem = false;
    public bool hoveringOverWindow = false;
    private bool canPickUp = true;
    private Vector3 offsetPos = new Vector3();
    
    private AudioSource _audio, _audio2;
    [SerializeField] private AudioClip[] audioOptions, pickUpAudio;
    private bool canPlayAudio = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCol = GetComponent<BoxCollider2D>();
        startScale = transform.localScale;
        _info = GetComponent<DisplayItemInfo>();
        _audio = GetComponent<AudioSource>();
        _audio2 = transform.GetChild(0).GetComponent<AudioSource>();
    }

    private void OnMouseDown() {
        if(canPickUp){
            if(!clickedOn){
                if(isShopItem){
                    if(ShopManager.Instance.money > GetComponent<CardDisplay>().smithingObjInfo.cost){
                        ShopManager.Instance.BuyItem();
                        isShopItem = false;
                    }else{
                        return;
                    }
                }
                clickedOn = true;
                PickUp();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(canPickUp){
            if(currentSlot==null){
                if(_rigidbody.velocity.magnitude>1)
                if(canPlayAudio){
                    _audio.clip = audioOptions[Random.Range(0,audioOptions.Length)];
                    _audio.pitch = 1+Random.Range(-0.1f,0.1f);
                    _audio.Play();
                }
            }
        }
    }
    
    private void Update() {
        if(clickedOn && !inSlot){
            if(Input.GetMouseButtonUp(0)){
                clickedOn = false;
                Release();
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(clickedOn && !inSlot){
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f; 
            //rotate
            if(horizontalMovementShift){
                moveRotation += (mouseWorldPos.x - transform.position.x) * rotationMulti;
            }else{
                moveRotation += (mouseWorldPos.y - transform.position.y) * rotationMulti;
            }
            if(Mathf.Abs(moveRotation) > rotationMomentum* Time.deltaTime){
                moveRotation += moveRotation>0?-rotationMomentum* Time.deltaTime:rotationMomentum * Time.deltaTime;
            }else{
                moveRotation = 0;
            }
            moveRotation = Mathf.Clamp(moveRotation, -rotationCap, rotationCap);
            transform.eulerAngles = new Vector3(0,0,-moveRotation);
            //move
            // transform.position = mouseWorldPos;
            Tweenmove(mouseWorldPos);
        }
    }
    public void FlickMovement(Vector2 flickPos, float flickSpeed){
        StartCoroutine(FlickPos(flickPos,flickSpeed));
    }
    private IEnumerator FlickPos(Vector2 flickPos, float flickSpeed){
        float timer = 0;
        while(timer< flickSpeed){
            timer+=Time.deltaTime;
            offsetPos = Mathf.Sin(timer/flickSpeed) * flickPos;
            yield return null;
        }
        yield return new WaitForEndOfFrame();
        offsetPos = new Vector3();
    }
    private void Tweenmove(Vector3 mousePos, float moveSpeed = 0.05f)
    {
        System.Action<ITween<Vector3>> updateItemMove = (t) =>
        {
            if(!destroyed)
            transform.position = t.CurrentValue;
        };

        System.Action<ITween<Vector3>> itemMoveCompleted = (t) =>
        {
        };
        Vector3 startPos = transform.position + offsetPos;
        // completion defaults to null if not passed in
        gameObject.Tween("MoveItem", startPos, mousePos + offsetPos, moveSpeed, TweenScaleFunctions.Linear, updateItemMove, itemMoveCompleted);
    }

    private void TweenPickUp()
    {
        System.Action<ITween<Vector3>> updateItemScale = (t) =>
        {
            if(!destroyed)
            transform.localScale = t.CurrentValue;
        };

        System.Action<ITween<Vector3>> itemMoveCompleted = (t) =>
        {
        };
        Vector3 tweenMid = startScale * tweenPickUpScaleMid;
        Vector3 tweenEnd = startScale * tweenPickUpScaleEnd;
        // completion defaults to null if not passed in
        gameObject.Tween("ScaleItem", startScale, tweenMid, tweenPickUpSpeed/3*2, TweenScaleFunctions.CubicEaseIn, updateItemScale, itemMoveCompleted)
            .ContinueWith(new Vector3Tween().Setup(tweenMid, tweenEnd, tweenPickUpSpeed/3, TweenScaleFunctions.CubicEaseOut, updateItemScale, itemMoveCompleted));
    }

    private void TweenPutDown()
    {
        System.Action<ITween<Vector3>> updateItemScale = (t) =>
        {
            if(!destroyed)
            transform.localScale = t.CurrentValue;
        };

        System.Action<ITween<Vector3>> itemMoveCompleted = (t) =>
        {

        };
        Vector3 tweenMid = startScale * tweenPickUpScaleMid;
        Vector3 tweenEnd = startScale * tweenPickUpScaleEnd;
        // completion defaults to null if not passed in
        gameObject.Tween("ScaleItem", tweenEnd, startScale, tweenPickUpSpeed/2, TweenScaleFunctions.CubicEaseInOut, updateItemScale, itemMoveCompleted);    
    }

    private void PickUp(){
        canPlayAudio = true;
        Cursor.visible = false;
        if(currentSlot!=null){
            currentSlot.GetComponent<ItemSlot>().RemoveFromSlot(this.gameObject);
        }
        CameraMovement.Instance.holdingSomething = true;
        TweenPickUp();
        transform.parent = null;
        inSlot = false;
        _rigidbody.constraints = RigidbodyConstraints2D.None;
        if(turnOffCollision){
            if(_boxCol!=null)
            _boxCol.isTrigger = true;
            _rigidbody.isKinematic = true;
        }
        if(_info!=null)
        _info.ShowDiscription();
        if(GetComponent<CardDisplay>()!=null){
            SlotManager.Instance.ShowSpecificSlots(GetComponent<CardDisplay>().smithingObjInfo, this.gameObject);
        }
        if(pickUpAudio.Length !=0){
            _audio2.clip = pickUpAudio[Random.Range(0,pickUpAudio.Length)];
            _audio2.pitch = 1+Random.Range(-0.1f,0.1f);
            _audio2.Play();
        }
    }
    private void Release(){
        Cursor.visible = true;
        CameraMovement.Instance.holdingSomething = false;
        SlotManager.Instance.HideAllSlots();
        if(_info!=null)
        _info.HideDiscription();
        if(hoveringOverWindow){
            //delivered drop
            GiveItemToCharacter.Instance.ReleaseItem();
            GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Characters");
            GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            transform.GetChild(2).GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Characters");    
            transform.GetChild(2).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

            TweenPutDown();
            //drop
            if(turnOffCollision){
                if(_boxCol!=null)
                _boxCol.isTrigger = false;
                _rigidbody.isKinematic = false;
            }
            canPickUp = false;
            StartCoroutine(DestroyInSeconds(2));
        }else{
            //normal drop
            if(currentSlot!=null){
                //slotIn
                LockInSlot();
            }else{
                TweenPutDown();
                //drop
                if(turnOffCollision){
                    if(_boxCol!=null)
                    _boxCol.isTrigger = false;
                    _rigidbody.isKinematic = false;
                }
            }
        }
    }
    private IEnumerator DestroyInSeconds(float duration){
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }
    public void LockInSlot(){
        inSlot = true;
        if(!currentSlot.GetComponent<ItemSlot>().connectedObjects.Contains(this.gameObject))
        Tweenmove(currentSlot.transform.GetChild(currentSlot.GetComponent<ItemSlot>().connectedObjects.Count).position, 0.3f);
        if(turnOffCollision){
            if(_boxCol!=null)
            _boxCol.isTrigger = false;
        }
        transform.localScale = startScale;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.eulerAngles = new Vector3(0,0,0);
        transform.parent = currentSlot.transform.parent;
        currentSlot.GetComponent<ItemSlot>().AttachToSlot(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Slot"){
            if(other.gameObject.GetComponent<ItemSlot>().CheckSlot(this.gameObject)){
                currentSlot = other.gameObject;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject == currentSlot && clickedOn){
            currentSlot.GetComponent<ItemSlot>().RemoveFromSlot(this.gameObject);
            currentSlot = null;
        }
    }
    void OnDestroy() {
        destroyed = true;
    }

}
