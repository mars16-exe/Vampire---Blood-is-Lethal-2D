using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D thisBody;
    private float horizontal;
    public float moveSpeed;
    public float jumpSpeed;
    [SerializeField] private float maxSpeedVertical = 3f;

    [SerializeField] private float groundCheckDistance = 0.7f;

    [SerializeField] private bool isGrounded = false;
    public bool isMovementON = true;

    [Header("Animation Department")]
    [SerializeField] private SpriteRenderer image_player;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        thisBody = this.gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
        image_player = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isMovementON)
        {
            HandleMovement();
            HandleJump();
        }

    }

    private void Update()
    {
        isGrounded = IsGrounded();
        animator.SetBool("isGrounded", isGrounded);
    }

    void HandleMovement()
    {
        horizontal = Input.GetAxis("Horizontal");

        HandleSpriteFlip(horizontal);       //handling sprite flip
        animator.SetFloat("horizontal", Mathf.Abs(horizontal));

        float currentSpeed = horizontal * moveSpeed * Time.deltaTime;
        float clampedSpeed = Mathf.Clamp(currentSpeed, -maxSpeedVertical, maxSpeedVertical);
        Vector2 currentVelocity = new Vector2(currentSpeed, thisBody.velocity.y);
        thisBody.velocity = currentVelocity;
    }

    void HandleSpriteFlip(float value)
    {
        if(value > 0)
        {
            image_player.flipX = false;
        }
        else if(value < 0)
        {
            image_player.flipX = true;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, 3);

        return hitInfo.collider != null;
    }

    void HandleJump()
    {
        float jump = Input.GetAxis("Jump");
        if (jump != 0 && isGrounded)
        {
            thisBody.velocity = new Vector2(thisBody.velocity.x, jump * jumpSpeed * Time.deltaTime);
            isGrounded = false;
            animator.SetBool("isGrounded", isGrounded);
        }
    }


    public void Drowning()
    {
        animator.SetTrigger("Drown");
    }
    //private void OnDrawGizmos()
    //{
    //    Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);
    //}
}
