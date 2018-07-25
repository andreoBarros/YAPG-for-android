using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform goPlayer;


    void Update()
    {
        transform.position =
            new Vector3(Mathf.Clamp(goPlayer.position.x, -0, 500), Mathf.Clamp(goPlayer.position.y, 3, 500), transform.position.z);
    }

}