using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleUpDown : MonoBehaviour
{
    private Vector3 startPos;
    [SerializeField] private float _upDownAmount, _upDownSpeed;
    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        _timer+=Time.deltaTime*_upDownSpeed;
        transform.localPosition = new Vector3(startPos.x, startPos.y + Mathf.Sin(_timer)*_upDownAmount, startPos.z);
    }
}
