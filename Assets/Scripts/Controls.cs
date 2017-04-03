using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public Rigidbody2D sonic;

    public Transform groundCheck;
    

    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool onGround;

    public float movespeed;
    public float jumpheight;

    [HideInInspector] public bool facingRight = true;
    public int mvinDirection = 1;
    public bool moveRight;
    public bool moveLeft;
    public bool jump;

    private Animator anim;


    public void Direction()
    {
        if (sonic.velocity == new Vector2(-movespeed, sonic.velocity.y))
        {
            mvinDirection = 0;
        }
        if (sonic.velocity == new Vector2(movespeed, sonic.velocity.y))
        {
            mvinDirection = 1;
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
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            sonic.velocity = new Vector2(sonic.velocity.x, jumpheight);
        }

        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && onGround)
        {
            sonic.velocity = new Vector2(0, sonic.velocity.y);
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
        if (jump && onGround)
        {
            sonic.velocity = new Vector2(sonic.velocity.x, jumpheight);
            jump = false;
        }
    }
  /*  private void spriteChanger()
    {
        if (sonic.velocity.y > 0 && !onGround)
        {
            anim.SetBool("jumping", true);
        }
        if (sonic.velocity.y == 0 && onGround)
        {
            anim.SetBool("jumping", false);
        }
        if (sonic.velocity.y < 0 && !onGround)
        {
            anim.SetBool("falling",true);
        }
        if (sonic.velocity.x > 0 && onGround)
        {
            anim.SetBool("walkRight", true);
        }
        if (sonic.velocity.x == 0 && onGround)
        {
            anim.SetBool("Standing", true);
        }
        if (sonic.velocity.x < 0 && onGround)
        {
            anim.SetBool("walkLeft", true);
        }
    } */
    private void spriteMirror()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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
        // spriteChanger();
        if (sonic.velocity.x > 0 && !facingRight)
            spriteMirror();
        else if (sonic.velocity.x < 0 && facingRight)
            spriteMirror();
    }
    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

}
