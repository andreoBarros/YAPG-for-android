using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataSobe : MonoBehaviour {

    private Vector2 startPosition;
    private int speed;

    void Start()
    {
        startPosition = transform.position;
        speed = 2;
    }

    void FixedUpdate()
    {
        transform.position =
            new Vector2( startPosition.x, Mathf.Abs(2*startPosition.y) + Mathf.Sin(Time.time)*3);
    }
}
