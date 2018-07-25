using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    private Rigidbody2D sonic;
    private Controls sonicControl;
    private Vector2 center;
    //sprites misaligned 
    float angle = 0f;

    // Use this for initialization
    void Start () {
        sonic = FindObjectOfType<Rigidbody2D>();
        sonicControl = FindObjectOfType<Controls>();
        center.x = 0; center.y = -1;
        sonic.centerOfMass = center;
    }

    // Update is called once per frame
    void Update () {
        // on this line, calculate condition for freezing rotation
        if (!sonicControl.onGround)
        {
          //  sonic.constraints = RigidbodyConstraints2D.FreezeRotation;
          //  sonic.rotation = angle;
        }
        else
        {
          //  sonic.constraints = RigidbodyConstraints2D.FreezeRotation;
           // sonic.rotation = angle;
        }
    }
}
