using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D rb2d;
    // ground
    private BoxCollider2D groundC;
    private SpriteRenderer pSprite;
    private Animator anim;

    [SerializeField] private LayerMask solidGround;

    private float move_x = 0f;
    // can edit values from with Unity
    [SerializeField] private float mSpeed = 7f;
    [SerializeField] private float jumpF = 20f;

    private enum MoveState{ idle, running, jumping, falling }

    // sound
    [SerializeField] private AudioSource sJumpEffect;

    // Start is called before the first frame update
  private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        groundC = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        pSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
   private void Update()
    {
        // get data
        move_x = Input.GetAxisRaw("Horizontal");
         // move left and right
        rb2d.velocity = new Vector2 (move_x * mSpeed, rb2d.velocity.y);
        //jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {   
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpF);
            sJumpEffect.Play();
        }
        
        PAnimationUpdate();
    }

    private void PAnimationUpdate()
    {
        // get movement state
        MoveState state;
// move right
        if (move_x > 0.1f)
        {
            state = MoveState.running;
            pSprite.flipX = false;
        }
        // move left
        else if (move_x < -0.1f)
        {
            state = MoveState.running;
            pSprite.flipX = true;
        }
        // idle
        else
        {
            state = MoveState.idle;
        }
        // jumping/falling
        if(rb2d.velocity.y > .1f)
        {
            state = MoveState.jumping;
        }
        else if (rb2d.velocity.y < -.1f)
        {
            state = MoveState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
    
    // slightly offset box overlaps with player collision, to find overlap with platforms
    private bool IsGrounded ()
    {
       return Physics2D.BoxCast(groundC.bounds.center, groundC.bounds.size, 0f, Vector2.down, .2f, solidGround);
    }
}
