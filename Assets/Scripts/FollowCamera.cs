using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour{

    public Transform goPlayer;
    
    void LateUpdate()
    {
        transform.position = new Vector3(goPlayer.position.x, goPlayer.position.y, transform.position.z);
    }
}