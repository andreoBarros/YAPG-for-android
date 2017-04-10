using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public Rigidbody2D sonic;

    public float groundnWallCheckRadius;
    public Transform groundCheck;
    public Transform pushingWall;
    public bool onGround;
    public bool pushWall;

    public LayerMask whatIsGround;
    public LayerMask whatIsBlock;


    [HideInInspector] private Vector2 movespeed;
    public float jumpheight;
    

    [HideInInspector] public bool facingRight = true;
//    public int mvinDirection = 1;
    public bool moveRight;
    public bool moveLeft;
    public bool jump;

    public Animator anim;

    
    public void Move() {

        if (Input.GetKey(KeyCode.LeftArrow) || moveLeft)
        {
            sonic.AddForceAtPosition(movespeed * -1, sonic.transform.position , ForceMode2D.Force);
            if (onGround)
            {
                sonic.AddForceAtPosition(sonic.transform.position, -movespeed * 3, ForceMode2D.Force);
            }
         
        }
        if (Input.GetKey(KeyCode.RightArrow) || moveRight)
        {
            sonic.AddForceAtPosition(movespeed, sonic.transform.position, ForceMode2D.Force);
            if (onGround)
            {
                sonic.AddForceAtPosition(sonic.transform.position, -movespeed * 3, ForceMode2D.Force);
            }
        } 
        if ((Input.GetKey(KeyCode.Space) || jump) && onGround)
        {
            sonic.velocity = new Vector2(sonic.velocity.x, jumpheight);
        }
      }
    private void animChanger()
    {
        if (sonic.velocity.y > 0 && !onGround)
        {
            anim.SetBool("jumping", true);
        }
        else
        {
            anim.SetBool("jumping", false);
        }

        if (sonic.velocity.y < 0 && !onGround)
        {
            anim.SetBool("falling",true);
        }
        else
        {
            anim.SetBool("falling", false);
        }

        if (sonic.velocity.x != 0 && onGround)
        {
            if (pushWall == true)
            {
                anim.SetBool("pushing", true);
            }
            else
            {
                anim.SetBool("pushing", false);
            }
            anim.SetBool("walk", true);

        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("pushing", false);


        }

        if (sonic.velocity.x == 0 && onGround)
        {
            anim.SetBool("standing", true);
        }
        else
        {
            anim.SetBool("standing", false);
        }


    }
    private void spriteMirror()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void LimitSpeed()
    {
        if (sonic.velocity.x > 10)
        {
            sonic.velocity = new Vector2(10, sonic.velocity.y);
        }
        else if (sonic.velocity.x < -10)
        {
            sonic.velocity = new Vector2(-10, sonic.velocity.y);
        }
        if (sonic.velocity.y > 10)
        {
            sonic.velocity = new Vector2(sonic.velocity.x,10);
        }
        else if (sonic.velocity.x < -10)
        {
            sonic.velocity = new Vector2(sonic.velocity.x,10);
        }
    }
  
    // Use this for initialization
    void Start () {
        sonic = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        movespeed = new Vector2 (50, sonic.velocity.y);
    }

    // Update is called once per frame
    void Update() {
        LimitSpeed();
        animChanger();
        Move();
        if (sonic.velocity.x > 0 && !facingRight)
        {
            spriteMirror();
        }
        else if (sonic.velocity.x < 0 && facingRight)
        {
            spriteMirror();
        }


    }
    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundnWallCheckRadius, whatIsGround);
        pushWall = Physics2D.OverlapCircle(pushingWall.position, groundnWallCheckRadius, whatIsBlock);
    }

}
