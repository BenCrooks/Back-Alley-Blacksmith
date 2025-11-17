using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperFrameRate : MonoBehaviour
{
    [SerializeField] private float frameRate;
    private SpriteRenderer _sprRen;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        _sprRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>=frameRate){
            timer=0;
            bool currentx = _sprRen.flipX;
            bool currenty = _sprRen.flipY;
            _sprRen.flipX = Random.Range(0f,1f)>0.5f;
            _sprRen.flipY = Random.Range(0f,1f)>0.5f;
            if(_sprRen.flipX == currentx && _sprRen.flipY == currenty){
                _sprRen.flipX = !_sprRen.flipX;
            }
        }
    }
}
