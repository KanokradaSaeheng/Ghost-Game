using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;

    public float groundCheckDistance = 0.1f; // ระยะของ Raycast
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = move;

        // Flip sprite when moving left or right
        if (horizontalInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void Jump()
    {
        // Function สำหรับตรวจจับว่าจะกระโดดได้ไหม
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnDrawGizmos()
    {
        // Function สำหรับสร้างเส้นตรงสีแดงของ Raycast
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
