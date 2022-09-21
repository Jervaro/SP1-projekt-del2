using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SlimeMovement : MonoBehaviour
{
    public float speed = 1f;
    public float impulseForce = 4f;
    public bool startMovingRight = true;
    public float checkRadius;

    [SerializeField] private LayerMask whatIsGround;

    Rigidbody2D rigidBody2D;
    private Animator animator;

    public GameObject groundCheck;
    public Transform frontCheck;

    private float movementDirection = 1f;
    private bool isGrounded;
    private bool isAlive = true;
    private bool isTouchingFront;

    // Start is called before the first frame update
    void Start()
    {
        if (startMovingRight)
        {
            movementDirection = 1f;
        }
        else
        {
            ChangeDirection();
            movementDirection = -1f;
        }

        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        // wall checking
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);
        if (isTouchingFront == true)
        {
            ChangeDirection();
        } 
        // end of wallchecking

        animator.SetBool("IsAlive", isAlive);
        animator.SetBool("IsGrounded", isGrounded);
    }

    void FixedUpdate()
    {
        if (isGrounded == true && isAlive == true)
        {
            Vector3 newPosition = gameObject.transform.position;
            newPosition.x += speed * Time.fixedDeltaTime * movementDirection;
            rigidBody2D.MovePosition(newPosition);

        }

        if (isAlive == true)
        {
            CheckForGround();

            if (isGrounded == false)
            {
                ChangeDirection();
            }
        }
    }

    private void CheckForGround()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
            }
        }
    }

    private void ChangeDirection()
    {
        
        movementDirection = -movementDirection;
        /*
        Vector3 newScale = gameObject.transform.localScale;
        newScale.x = movementDirection;
        gameObject.transform.localScale = newScale;
        */
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") == true)
        {
            ChangeDirection();
        }

        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            ChangeDirection();
        }
    }

    public void KillMe()
    {
        isAlive = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Vector2 killForce = new Vector2(movementDirection, impulseForce);
        rigidBody2D.AddForce(killForce, ForceMode2D.Impulse);
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, -gameObject.transform.localScale.y);

        Debug.Log("d�d");
        Invoke("DestroySlime", 5f);
    }
    
    void DestroySlime()
    {
        Debug.Log("invokeslime");
        Destroy(gameObject);
    }

}
