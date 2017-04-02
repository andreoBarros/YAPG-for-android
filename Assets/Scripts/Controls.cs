using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public Rigidbody2D sonic;

    public float movespeed;
    public float jumpheight;

    public int mvinDirection;
    public bool moveRight;
    public bool moveLeft;
    public bool jump;

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
        if (Input.GetKey(KeyCode.Space))
        {
            sonic.velocity = new Vector2(sonic.velocity.x, jumpheight);
        }
    }
    public void touchMove()
    {
        if (moveRight)
        {
            sonic.velocity = new Vector2(movespeed, sonic.velocity.y);
        }
        if (moveLeft)
        {
            sonic.velocity = new Vector2(-movespeed, sonic.velocity.y);
        }
        if (jump)
        {
            sonic.velocity = new Vector2(sonic.velocity.x, jumpheight);
            jump = false;
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

        touchMove();
      

    }

}
