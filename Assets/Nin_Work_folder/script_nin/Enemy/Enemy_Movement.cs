using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 2f; // ความเร็วในการเดิน
    public float patrolTime = 3f; // เวลาที่เดินไปในแต่ละทิศทาง
    public float waitTime = 2f; // เวลาที่หยุดเดิน

    [Header("Detection Settings")]
    public Transform player; // ตัวผู้เล่น
    public float detectionRange = 5f; // ระยะที่ Enemy จะเดินตามผู้เล่น
    private bool canDetectPlayer = true; // Whether the enemy can detect the player

    [Header("Physics Settings")]
    public LayerMask groundLayer; // Layer ของพื้น
    public Transform groundCheck; // จุดตรวจสอบพื้น
    public float groundCheckRadius = 0.2f; // รัศมีตรวจสอบพื้น

    private float patrolTimer;
    private float waitTimer;
    private bool isFacingRight = true; // Enemy หันไปทางขวา
    private bool isGrounded;
    private bool isWaiting = false; // สถานะ "หยุดเดิน"
    private Rigidbody2D rb;

    // Animation
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        patrolTimer = patrolTime; // เริ่มต้นการเดินแบบ Patrol
        waitTimer = waitTime; // ตั้งค่าช่วงเวลาที่หยุดเดิน
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ตรวจสอบว่าอยู่บนพื้นหรือไม่
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (canDetectPlayer)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange)
            {
                FollowPlayer();
            }
            else
            {
                Patrol();
            }
        }
        else
        {
            Patrol(); // Continue patrolling even if detection is disabled
        }
    }

    private void FollowPlayer()
    {
        // เดินตามผู้เล่นในแนวนอน
        if (player.position.x > transform.position.x && !isFacingRight)
            Flip();
        else if (player.position.x < transform.position.x && isFacingRight)
            Flip();

        Vector2 targetVelocity = new Vector2((player.position.x > transform.position.x ? 1 : -1) * speed, rb.linearVelocity.y);
        rb.linearVelocity = targetVelocity;  // Change to linearVelocity to avoid warning
        // Replace above line with:
        rb.linearVelocity = targetVelocity;

        animator.SetBool("Running", true);
        animator.SetBool("Idle", false);
    }

    private void Patrol()
    {
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;

            // เมื่อเวลาหยุดเดินหมด
            if (waitTimer <= 0)
            {
                isWaiting = false;
                patrolTimer = patrolTime; // รีเซ็ตเวลาสำหรับเดิน
            }

            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // หยุดการเคลื่อนไหว
            animator.SetBool("Running", false);
            animator.SetBool("Idle", true);
        }
        else
        {
            patrolTimer -= Time.deltaTime;

            // เมื่อเวลาสำหรับเดินหมด
            if (patrolTimer <= 0)
            {
                Flip();
                isWaiting = true; // เปลี่ยนสถานะเป็นหยุด
                waitTimer = waitTime; // รีเซ็ตเวลาหยุด
            }

            rb.linearVelocity = new Vector2((isFacingRight ? 1 : -1) * speed, rb.linearVelocity.y);
            animator.SetBool("Running", true);
            animator.SetBool("Idle", false);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmosSelected()
    {
        // แสดงระยะตรวจจับผู้เล่นใน Scene View
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // แสดงตำแหน่งและรัศมีของ Ground Check
        if (groundCheck != null)
        {
            Gizmos.color = Color.green; // สีเขียวสำหรับ Ground Check
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

            // เส้นเชื่อมจาก Enemy ไปยัง Ground Check
            Gizmos.color = Color.yellow; // สีเหลืองสำหรับเส้นเชื่อม
            Gizmos.DrawLine(transform.position, groundCheck.position);
        }
    }

    // This method is called to disable detection of the player
    public void DisableDetection()
    {
        canDetectPlayer = false;
    }

    // This method is called to re-enable detection of the player
    public void EnableDetection()
    {
        canDetectPlayer = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // เริ่มอนิเมชั่นโจมตี
            animator.SetBool("isAttack", true);
            animator.SetBool("Running", false);
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("Idle", true);
            animator.SetBool("Running", false);
        }
    }
}
