using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f, jumpForce = 12f;
    [SerializeField]
    private LayerMask jumpableGround;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    private bool isFacingLeft = false;
    private bool isRunning = false;

    private int jumpCounter = 0;

    [SerializeField]
    private AudioSource jumpSoundEffect;
    private enum MovementState { idle, running, jumping, falling, doubleJumping }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        rb.WakeUp();
    }

    private void Update()
    {
        AnimationUpdate();
        JumpUpdate();
    }

    private void AnimationUpdate()
    {
        MovementState state;

        if (isFacingLeft)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (jumpCounter == 0 && rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        else if(jumpCounter == 1)
        {
            state = MovementState.doubleJumping;
        }
        else if (isRunning && jumpCounter == 0)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void Jump()
    {
        if (jumpCounter < 1)
        {
            if (PlayerPrefs.GetInt("soundEffects") == 1) jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCounter++;
        }
    }

    private void JumpUpdate()
    {
        if (IsGrounded())
        {
            jumpCounter = 0;
        }
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        isFacingLeft = false;
        isRunning = true;
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        isFacingLeft = true;
        isRunning = true;
    }

    public void Stop()
    {
        isRunning = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
}