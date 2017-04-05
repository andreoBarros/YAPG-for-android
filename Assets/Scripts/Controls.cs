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
    
    public float movespeed;
    public float jumpheight;

    [HideInInspector] public bool facingRight = true;
    public int mvinDirection = 1;
    public bool moveRight;
    public bool moveLeft;
    public bool jump;

    public Animator anim;


    public int Direction()
    {
        if (sonic.velocity.x == -movespeed)
        {
            return -1;
        }
        else if (sonic.velocity.x == movespeed)
        {
            return 1;
        }

        return 0;
        
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
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            sonic.velocity = new Vector2(sonic.velocity.x, jumpheight);
        }

        /*       if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && onGround)
               {
                   sonic.velocity = new Vector2(0, sonic.velocity.y);
               } */
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
        if (jump && onGround)
        {
            sonic.velocity = new Vector2(sonic.velocity.x, jumpheight);
            jump = false;
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
            do
            {
                anim.SetBool("walk", false);
                anim.SetBool("standing", false);
                anim.SetBool("pushing", true);

            } while (pushWall == true);

            if (pushWall == false)
            {
                anim.SetBool("walk", true);
                anim.SetBool("pushing", false);
            }

        }
        else
        {
            anim.SetBool("walk", false);
      
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

    private void isItpushing()
    {
        if (Physics2D.OverlapCircle(pushingWall.position, groundnWallCheckRadius, whatIsGround) && (moveRight || moveLeft) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            pushWall = true;
        }
        else
        {
            pushWall = false;
        }
    }
    // Use this for initialization
    void Start () {
        sonic = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {

        animChanger();
        Direction();
        kboardMove();
        touchMove();
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
    }

}
