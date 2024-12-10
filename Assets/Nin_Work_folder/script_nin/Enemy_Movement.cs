using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 2f; // ความเร็วในการเดิน
    public float patrolTime = 3f; // เวลาที่เดินไปในแต่ละทิศทาง

    [Header("Detection Settings")]
    public Transform player; // ตัวผู้เล่น
    public float detectionRange = 5f; // ระยะที่ Enemy จะเดินตามผู้เล่น

    [Header("Physics Settings")]
    public LayerMask groundLayer; // Layer ของพื้น
    public Transform groundCheck; // จุดตรวจสอบพื้น
    public float groundCheckRadius = 0.2f; // รัศมีตรวจสอบพื้น

    private float patrolTimer;
    private bool isFacingRight = true; // Enemy หันไปทางขวา
    private bool isGrounded;
    private Rigidbody2D rb;

    // Animation 
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        patrolTimer = patrolTime; // เริ่มต้นการเดินแบบ Patrol
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ตรวจสอบว่าอยู่บนพื้นหรือไม่
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

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

    private void FollowPlayer()
    {
        // เดินตามผู้เล่นในแนวนอน
        if (player.position.x > transform.position.x && !isFacingRight)
            Flip();
        else if (player.position.x < transform.position.x && isFacingRight)
            Flip();

        Vector2 targetVelocity = new Vector2((player.position.x > transform.position.x ? 1 : -1) * speed, rb.linearVelocity.y);
        rb.linearVelocity = targetVelocity;

        animator.SetBool("Running", true);
        animator.SetBool("Idle", false);
        // animator.SetBool("isAttack", false);
    }

    private void Patrol()
    {
        // เดินซ้าย-ขวาเมื่อไม่พบผู้เล่น
        patrolTimer -= Time.deltaTime;

        if (patrolTimer <= 0)
        {
            Flip();
            patrolTimer = patrolTime;
        }

        rb.linearVelocity = new Vector2((isFacingRight ? 1 : -1) * speed, rb.linearVelocity.y);
        animator.SetBool("Running", true);
        animator.SetBool("Idle", false);
        animator.SetBool("isAttack", false);
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // เริ่มอนิเมชั่นโจมตี
            animator.SetBool("isAttack" , true);
            animator.SetBool("Running", false);

        }
        else
        {
            animator.SetBool("isAttack", false);
        }

    }
}
    