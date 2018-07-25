using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public Rigidbody2D sonic;

    public Transform groundCheck;
    public bool onGround;
    public float groundnWallCheckRadius;

    public Transform pushingWall;
    public bool pushWall;

    public LayerMask whatIsGround;
    public LayerMask whatIsBlock;

    [HideInInspector] public bool facingRight = true;
 // Touch screen control signals
    public bool moveRight;
    public bool moveLeft;
    public bool jump;
// Jump stuff
    private bool canDoubleJump;
    public bool doubleJumpTouch = false;
    public Animator anim;

    
    public void Move() {
        if (Input.GetKey(KeyCode.LeftArrow) || moveLeft)
        {
            sonic.AddForce(-transform.right * 60);
        }
        if (Input.GetKey(KeyCode.RightArrow) || moveRight)
        {
            sonic.AddForce(transform.right * 60);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                sonic.AddForce(transform.up * 15, ForceMode2D.Impulse);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    sonic.velocity = new Vector2(sonic.velocity.x, 0);
                    //sonic.velocity = new Vector2(sonic.velocity.x, jumpheight);
                    sonic.AddForce(transform.up * 15, ForceMode2D.Impulse);
                    canDoubleJump = false;
                }
            }
        }
        if (jump && onGround)
        {
            sonic.AddForce(transform.up * 15, ForceMode2D.Impulse);
           
        }
        if (doubleJumpTouch)
        {
            sonic.velocity = new Vector2(sonic.velocity.x, 0);
            //sonic.velocity = new Vector2(sonic.velocity.x, jumpheight);
            sonic.AddForce(transform.up * 15, ForceMode2D.Impulse);
            sonic.AddForce(transform.right * 15, ForceMode2D.Impulse);
        }
    }
    private void Push()
    {
        if (pushWall == true)
        {
            anim.SetBool("pushing", true);
        }
        else
        {
            anim.SetBool("pushing", false);
        }
    }
    private void AnimChanger()
    {
        if (sonic.velocity.y > 0 && !onGround)
        {
            Push();
            anim.SetBool("jumping", true);
        }
        else
        {
            anim.SetBool("jumping", false);
        }

        if (sonic.velocity.y < 0 && !onGround)
        {
            Push();
            anim.SetBool("falling",true);
        }
        else
        {
            anim.SetBool("falling", false);
        }

        if (sonic.velocity.x != 0 && onGround)
        {
            Push();
            anim.SetBool("walk", true);

        }
        else
        {
            anim.SetBool("walk", false);
        }

        if (Mathf.Abs(sonic.velocity.x) < 2 && onGround)
        {
            Push();
            anim.SetBool("standing", true);
        }
        else
        {
            anim.SetBool("standing", false);
        }


    }
    private void SpriteMirror()
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
    }

    // Update is called once per frame
    void Update() {
        LimitSpeed();
        AnimChanger();
        Move();
        if (sonic.velocity.x > 0 && !facingRight)
        {
            SpriteMirror();
        }
        else if (sonic.velocity.x < 0 && facingRight)
        {
            SpriteMirror();
        }

    }
    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundnWallCheckRadius, whatIsGround);
        pushWall = Physics2D.OverlapCircle(pushingWall.position, groundnWallCheckRadius, whatIsGround);
    }

}
