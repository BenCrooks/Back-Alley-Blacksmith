using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjPos : MonoBehaviour
{
    [SerializeField] private Transform posToFollow;


    // Update is called once per frame
    void Update()
    {
        transform.position = posToFollow.position;
    }
}
