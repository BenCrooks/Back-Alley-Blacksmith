using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalLogic : MonoBehaviour
{
    [SerializeField] private Color coalCold, coalHot;
    [SerializeField] private float hotTime;
    [HideInInspector] public float heatTimer;
    private SpriteRenderer _spriteRenderer;
    public float coalHeat0To1;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetHot(){
        heatTimer = hotTime;
        _spriteRenderer.color = coalHot;
    }

    // Update is called once per frame
    void Update()
    {
        if(heatTimer>0){
            heatTimer -= Time.deltaTime;
            if(heatTimer<=0){
                heatTimer = 0;   
            }
            coalHeat0To1 = heatTimer/hotTime;
            _spriteRenderer.color = Color.Lerp(coalCold, coalHot, heatTimer/hotTime);
        }
    }
}
