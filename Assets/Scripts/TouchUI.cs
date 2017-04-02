using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchUI : MonoBehaviour {

    private Controls player;
    // Use this for initialization

    void Start () {
        player = FindObjectOfType<Controls>();
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

		
}
