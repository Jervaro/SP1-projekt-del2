using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Start of class

    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    public GameObject groundCheck;
    private bool isGrounded;

    public float movementSpeed = 2f;
    private float defaultMovementSpeed;

    private float moveDirection = 0f;
    private bool isMoving;
    private bool isJumpPressed = false;
    public float jumpForce = 10f;

    private bool isFacingLeft = false;

    private Vector3 velocity;
    public float smoothTime = 0.2f;

    [SerializeField] private LayerMask whatIsGround;

    public float checkRadius;
    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;

    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;

    // Start is called before the first frame update
    void Start()
    {
        defaultMovementSpeed = movementSpeed;
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Start of Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            isJumpPressed = true;
            animator.SetTrigger("DoJump");
            if (isGrounded == true)
            {
                audioSource.PlayOneShot(audioClip);
            }

        }

        // start of wallsliding/walljumping
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

        if (isTouchingFront == true && isGrounded == false && moveDirection != 0)
        {
            wallSliding = true;

        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, Mathf.Clamp(rigidBody2D.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if (Input.GetKeyDown(KeyCode.W) && wallSliding == true)
        {
            wallJumping = true;
            Invoke("setWallJumpingToFalse", wallJumpTime);
        }

        if (wallJumping == true)
        {
            rigidBody2D.velocity = new Vector2(xWallForce * -moveDirection, yWallForce);
        }
        // end of walljumping/wallsliding
        
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(moveDirection));

    }

    // Start of FixedUpdate method
    private void FixedUpdate()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.1f, whatIsGround);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
            }
        }

        Vector3 calculatedMovement = Vector3.zero;
        float verticalVelocity = 0f;

        if (isGrounded == false)
        {
            verticalVelocity = rigidBody2D.velocity.y;
        }

        calculatedMovement.x = movementSpeed * 100f * moveDirection * Time.fixedDeltaTime;
        calculatedMovement.y = verticalVelocity;
        Move(calculatedMovement, isJumpPressed);
        isJumpPressed = false;

      

    }

    private void Move(Vector3 moveDirection, bool isJumpPressed)
    {
        rigidBody2D.velocity = Vector3.SmoothDamp(rigidBody2D.velocity, moveDirection, ref velocity, smoothTime);

        if (isJumpPressed == true && isGrounded == true)
        {
            rigidBody2D.AddForce(new Vector2(0f, jumpForce * 100f));
        }

        if (moveDirection.x > 0 && isFacingLeft)
        {
            FlipSpriteDirection();
        }
        else if (moveDirection.x < 0 && !isFacingLeft)
        {
            FlipSpriteDirection();
        }

    }// End of Move method

    private void FlipSpriteDirection()
    {
        // spriteRenderer.flipX = !isFacingLeft;
        transform.Rotate(0f, 180f, 0f);
        isFacingLeft = !isFacingLeft;
    }

    public bool isFalling()
    {
        if (rigidBody2D.velocity.y < -1f)
        {
            return true;
        }
        return false;
    }

    public void ResetMovementSpeed()
    {
        movementSpeed = defaultMovementSpeed;
    }

    public void SetNewMovementSpeed(float multiplyBy)
    {
        movementSpeed *= multiplyBy;
    }

  
    
   private void setWallJumpingToFalse() 
    {
        wallJumping = false;
    }

} // End of class


