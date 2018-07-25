using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBackground : MonoBehaviour
{

    private Renderer back;
    private float vel;
    private string nomeBack;
    public Rigidbody2D speedRef;

    void Start()
    {

        back = GetComponent<Renderer>();
        nomeBack = this.gameObject.tag;

    }

    // Update is called once per frame
    void Update()
    {



        switch (nomeBack)
        {
            case "ceu4":
                
                vel = speedRef.velocity.x / 650;
                break;
            case "ceu3":
                
                break;

            case "ceu2":
                
                vel = speedRef.velocity.x / 500;
                break;

            case "ceu1":
            
                vel = speedRef.velocity.x / 200;
                break;

        }

        Vector2 offset = new Vector2(vel * Time.deltaTime, 0);

        back.material.mainTextureOffset += offset;

    }
}