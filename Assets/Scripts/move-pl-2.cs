using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movepl2 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f; 
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false; 
    private float groundCheckRadius = 0.2f; 
    public LayerMask groundLayer; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing on the GameObject.");
        }
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position, groundCheckRadius, groundLayer);

        bool isMoveLeftKeyPressed = Input.GetKey(KeyCode.LeftArrow);
        bool isMoveRightKeyPressed = Input.GetKey(KeyCode.RightArrow);

        if (isMoveLeftKeyPressed || isMoveRightKeyPressed)
        {
            animator.SetBool("stop", false);
            if (isMoveLeftKeyPressed)
            {
                transform.localScale = new Vector3(-5, 5, 1); 
            }
            else
            {
                transform.localScale = new Vector3(5, 5, 1); 
            }
        }
        else
        {
            animator.SetBool("stop", true);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        }

        float horizontalVelocity = (isMoveLeftKeyPressed ? -1 : 0) + (isMoveRightKeyPressed ? 1 : 0);
        rb.velocity = new Vector2(horizontalVelocity * speed, rb.velocity.y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
    }
}