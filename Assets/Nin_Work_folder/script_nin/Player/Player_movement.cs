using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 8f; // ความเร็วเมื่อวิ่ง
    public float jumpForce = 10f;

    public float dashDistance = 10f; // ระยะที่ Dash ได้
    public float dashDuration = 0.5f; // ระยะเวลาในการ Dash
    public LayerMask enemyLayer; // Layer ของศัตรู

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDashing = false;

    public float groundCheckDistance = 0.1f; // ระยะของ Raycast
    public LayerMask groundLayer;

    private Collider2D playerCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (!isDashing) // ห้ามเดินหรือกระโดดระหว่าง Dash
        {
            Move();
            Jump();
        }

        // ตรวจสอบการกดปุ่ม Q เพื่อ Dash
        if (Input.GetKeyDown(KeyCode.E) && !isDashing)
        {
            StartCoroutine(Dash_Right());
        }else if (Input.GetKeyDown(KeyCode.Q) && !isDashing)
        {
            StartCoroutine(Dash_Left());
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // ตรวจสอบว่ากด Shift หรือไม่
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;

        Vector2 move = new Vector2(horizontalInput * currentSpeed, rb.linearVelocity.y);
        rb.linearVelocity = move;

        // Flip sprite when moving left or right
        if (horizontalInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void Jump()
    {
        // ตรวจจับว่าอยู่บนพื้นหรือไม่
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    IEnumerator Dash_Right()
    {
        isDashing = true;

        // คำนวณทิศทาง Dash
        float dashDirection = transform.localScale.x; // 1 หรือ -1 ขึ้นกับทิศที่ผู้เล่นหัน
        Vector2 dashVelocity = new Vector2(dashDirection * dashDistance / dashDuration, 0);

        // ปิดการชนกับศัตรูชั่วคราว
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), true);

        rb.linearVelocity = dashVelocity;

        yield return new WaitForSeconds(dashDuration);

        rb.linearVelocity = Vector2.zero; // หยุดหลัง Dash เสร็จ
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), false);

        isDashing = false;
    }

    IEnumerator Dash_Left()
    {
        isDashing = true;

        // คำนวณทิศทาง Dash
        float dashDirection = transform.localScale.x; // 1 หรือ -1 ขึ้นกับทิศที่ผู้เล่นหัน
        Vector2 dashVelocity = new Vector2(-(dashDirection * dashDistance / dashDuration ), 0 );

        // ปิดการชนกับศัตรูชั่วคราว
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), true);

        rb.linearVelocity = dashVelocity;

        yield return new WaitForSeconds(dashDuration);

        rb.linearVelocity = Vector2.zero; // หยุดหลัง Dash เสร็จ
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), false);

        isDashing = false;
    }

    void OnDrawGizmos()
    {
        // สร้างเส้นตรงสีแดงของ Raycast
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
