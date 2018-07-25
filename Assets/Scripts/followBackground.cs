using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followBackground : MonoBehaviour {

    public Transform follow;

   
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position =
                    new Vector3(Mathf.Clamp(follow.position.x, -0, 500), transform.position.y, transform.position.z);
    }
}
