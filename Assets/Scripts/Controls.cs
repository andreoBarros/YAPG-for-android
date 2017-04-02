using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public Rigidbody2D sonic;

    public float movespeed;
    public int mvinDirection;
    public bool moveRight;
    public bool moveLeft;

    public void Direction()
    {
        if (sonic.velocity == new Vector2(-movespeed, sonic.velocity.y))
        {
            mvinDirection = -1;

        }
        else if (sonic.velocity == new Vector2(movespeed, sonic.velocity.y))
        {
            mvinDirection = 1;
        }
        else
        {
            mvinDirection = 0;
        }
    }
    public void kboardMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sonic.velocity = new Vector2(-movespeed, sonic.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sonic.velocity = new Vector2(movespeed, sonic.velocity.y);
        }
    }

    // Use this for initialization
    void Start () {
        sonic = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        Direction();

        kboardMove();

        if (moveRight)
        {
            sonic.velocity = new Vector2(movespeed, sonic.velocity.y);
        }
        if (moveLeft)
        {
            sonic.velocity = new Vector2(-movespeed, sonic.velocity.y);
        }

    }

}
