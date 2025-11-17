using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DigitalRuby.Tween;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float idleMoveAmount, idleMoveSpeed, idleSpeedRandomizer = 0.1f;
    public Transform lookAt;
    [SerializeField] private Transform[] rooms;
    private int lookingAtRoom = 1;
    [SerializeField] private Button arrrowLeft, arrowRight;
    [HideInInspector] public bool holdingSomething = false;
    [SerializeField] private float changeScreenArea = 15;
    private float changeScreenTime = 1, changeScreenTimer=0;
    public static CameraMovement Instance {get; private set;}
    private AudioSource _audio;
    [SerializeField] private AudioClip[] audioOptions;

    // Start is called before the first frame update
    void Start()
    {
        TweenMove(idleMoveSpeed + Random.Range(-idleSpeedRandomizer,idleSpeedRandomizer));
        Instance = this;
        holdingSomething = false;
        _audio = GetComponent<AudioSource>();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
            ChangeRoomSelection(-1);
        }else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
            ChangeRoomSelection(1);
        }
        //swipe left or right
        if(changeScreenTimer >= changeScreenTime){
            if(holdingSomething){
                if(Input.mousePosition.x < changeScreenArea){
                    ChangeRoomSelection(-1);
                    changeScreenTimer=0;
                }else if(Input.mousePosition.x > Camera.main.pixelWidth - changeScreenArea){
                    ChangeRoomSelection(1);
                    changeScreenTimer=0;
                }
            }
        }else{
            changeScreenTimer += Time.deltaTime;
        }
    }

    private void TweenMove(float moveTime)
    {
        System.Action<ITween<Vector3>> updateCirclePos = (t) =>
        {
            transform.position = t.CurrentValue;
        };

        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(Random.Range(-idleMoveAmount, idleMoveAmount),Random.Range(-idleMoveAmount, idleMoveAmount));

        System.Action<ITween<Vector3>> circleMoveCompleted = (t) =>
        {
            TweenMove(idleMoveSpeed + Random.Range(-idleSpeedRandomizer,idleSpeedRandomizer));
        };

        // completion defaults to null if not passed in
        gameObject.Tween("MoveCam", startPos, lookAt.position + endPos,moveTime , TweenScaleFunctions.QuinticEaseInOut, updateCirclePos, circleMoveCompleted);
            // .ContinueWith(new Vector3Tween().Setup(startPos, endPos, idleMoveSpeed, TweenScaleFunctions.CubicEaseOut, updateCirclePos, circleMoveCompleted));
    }
    private void TweenMoveScene(float moveTime)
    {
        System.Action<ITween<Vector3>> updateCirclePos = (t) =>
        {
            transform.position = t.CurrentValue;
        };

        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(Random.Range(-idleMoveAmount, idleMoveAmount),Random.Range(-idleMoveAmount, idleMoveAmount));

        System.Action<ITween<Vector3>> circleMoveCompleted = (t) =>
        {
            TweenMove(idleMoveSpeed + Random.Range(-idleSpeedRandomizer,idleSpeedRandomizer));
        };

        // completion defaults to null if not passed in
        gameObject.Tween("MoveCam", startPos, lookAt.position + endPos,moveTime , TweenScaleFunctions.QuadraticEaseInOut, updateCirclePos, circleMoveCompleted);
            // .ContinueWith(new Vector3Tween().Setup(startPos, endPos, idleMoveSpeed, TweenScaleFunctions.CubicEaseOut, updateCirclePos, circleMoveCompleted));
    }

    public void ChangeRoomSelection(int changeIndex){
        if(lookingAtRoom + changeIndex >= 0 && lookingAtRoom + changeIndex < rooms.Length){
            lookingAtRoom += changeIndex;
            lookAt = rooms[lookingAtRoom];
            TweenMoveScene(0.5f);
            if(lookingAtRoom == 0){
                arrrowLeft.interactable = false;
            }else{
                arrrowLeft.interactable = true;
            }
            if(lookingAtRoom == rooms.Length-1){
                arrowRight.interactable = false;
            }else{
                arrowRight.interactable = true;
            }
            _audio.clip = audioOptions[Random.Range(0,audioOptions.Length)];
            _audio.Play();
        }
    }
}
