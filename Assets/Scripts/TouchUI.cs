using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchUI : MonoBehaviour {

    private Controls player;
    private Rigidbody2D sonic;
    private int touchCounter = 0;
    private int secondCounter = 0;
    private bool seccondJumpTouch;
    // Use this for initialization

    void Start () {
        player = FindObjectOfType<Controls>();
        sonic = FindObjectOfType<Rigidbody2D>();
	}


    public void LeftArrow()
    {
        player.moveRight = false;
        player.moveLeft = true;
    }
    public void RightArrow()
    {
        player.moveRight = true;
        player.moveLeft = false;
    }
    public void ReleaseLeftArrow()
    {
        player.moveLeft = false;
    }
    public void ReleaseRightArrow()
    {
        player.moveRight = false;
    }

    public void Jump()
    {
            player.jump = true;
    
            touchCounter++;
     
    }
    public void ReleaseJump()
    {
            player.jump = false;
    }

    private void Update()
    {
        if (player.onGround == true)
        {
            touchCounter = 0;
        }
        if (touchCounter == 2)
        {
            player.doubleJumpTouch = true;
            touchCounter = 0;
        }
        else
        {
            player.doubleJumpTouch = false;
        }
    }


}
